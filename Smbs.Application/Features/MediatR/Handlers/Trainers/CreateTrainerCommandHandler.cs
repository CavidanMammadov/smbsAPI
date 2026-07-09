using MediatR;
using Smbs.Application.Features.MediatR.Commands.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

public class CreateTrainerCommandHandler
    : IRequestHandler<CreateTrainerCommand, IResult<DomainSuccess<TrainerResult>, DomainError>>
{
    private readonly ITrainerRespository _trainerRepository;
    private readonly ICloudinaryService _cloudinaryService;

    public CreateTrainerCommandHandler(
        ITrainerRespository trainerRepository,
        ICloudinaryService cloudinaryService)
    {
        _trainerRepository = trainerRepository;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<IResult<DomainSuccess<TrainerResult>, DomainError>> Handle(
        CreateTrainerCommand request,
        CancellationToken cancellationToken)
    {
        string? imageUrl = null;
        string? videoUrl = null;

        try
        {
            // IMAGE UPLOAD
            if (request.TrainerImgUrl != null && request.TrainerImgUrl.Length > 0)
            {
                var (url, _, error) =
                    await _cloudinaryService.UploadImageAsync(
                        request.TrainerImgUrl,
                        "trainers/images");

                if (!string.IsNullOrWhiteSpace(error))
                {
                    return Result.Fail<TrainerResult>(
                        DomainError.BadRequest($"Cloudinary image error: {error}"));
                }

                imageUrl = url;
            }

            // VIDEO UPLOAD (OPTIONAL)
            if (request.TrainerVideo != null && request.TrainerVideo.Length > 0)
            {
                var (url, _, error) =
                    await _cloudinaryService.UploadVideoAsync(
                        request.TrainerVideo,
                        "trainers/videos");

                if (!string.IsNullOrWhiteSpace(error))
                {
                    if (!string.IsNullOrWhiteSpace(imageUrl))
                    {
                        await _cloudinaryService.DeleteImageAsync(imageUrl);
                    }

                    return Result.Fail<TrainerResult>(
                        DomainError.BadRequest($"Cloudinary video error: {error}"));
                }

                videoUrl = url;
            }

            var trainer = new Trainer
            {
                TrainerNameAndSurname = request.TrainerNameAndSurname,
                TrainerPosition = request.TrainerPosition,
                TrainerDescription = request.TrainerDescription,

                // optional
                TrainerTrainingVideoUrl = videoUrl,

                TrainerImgUrl = imageUrl
            };

            await _trainerRepository.Create(trainer);

            var result = new TrainerResult
            {
                TrainerId = trainer.TrainerId,
                TrainerNameAndSurname = trainer.TrainerNameAndSurname,
                TrainerPosition = trainer.TrainerPosition,
                TrainerDescription = trainer.TrainerDescription,
                TrainerTrainingVideoUrl = trainer.TrainerTrainingVideoUrl,
                TrainerImgUrl = trainer.TrainerImgUrl
            };

            return Result.Success(DomainSuccess<TrainerResult>.Created(result));
        }
        catch (Exception ex)
        {
            // rollback uploaded files
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                await _cloudinaryService.DeleteImageAsync(imageUrl);
            }

            if (!string.IsNullOrWhiteSpace(videoUrl))
            {
                await _cloudinaryService.DeleteVideoAsync(videoUrl);
            }

            return Result.Fail<TrainerResult>(
                DomainError.BadRequest($"Unexpected error: {ex.Message}"));
        }
    }
}