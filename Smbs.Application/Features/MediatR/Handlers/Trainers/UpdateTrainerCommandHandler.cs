using MediatR;
using Microsoft.AspNetCore.Hosting;
using Smbs.Application.Features.MediatR.Commands.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainers
{
    #region old version
    //    public class UpdateTrainerCommandHandler
    //: IRequestHandler<UpdateTrainerCommand, IResult<DomainSuccess<TrainerResult>, DomainError>>
    //    {
    //        private readonly IRepository<Trainer> _trainerRepository;

    //        public UpdateTrainerCommandHandler(IRepository<Trainer> trainerRepository)
    //        {
    //            _trainerRepository = trainerRepository;
    //        }

    //        public async Task<IResult<DomainSuccess<TrainerResult>, DomainError>> Handle(
    //            UpdateTrainerCommand request,
    //            CancellationToken cancellationToken)
    //        {
    //            // ✅ 1. Trainer tap
    //            var trainer = await _trainerRepository.GetById(request.TrainerId);

    //            if (trainer == null)
    //                return Result.Fail<TrainerResult>(DomainError.NotFound("Trainer not found"));

    //            string imageUrl = trainer.TrainerImgUrl;

    //            // ✅ 2. Yeni şəkil gəlibsə
    //            if (request.TrainerImgUrl != null && request.TrainerImgUrl.Length > 0)
    //            {
    //                var extension = Path.GetExtension(request.TrainerImgUrl.FileName);
    //                var fileName = Guid.NewGuid() + extension;

    //                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/trainers");

    //                if (!Directory.Exists(folderPath))
    //                    Directory.CreateDirectory(folderPath);

    //                var fullPath = Path.Combine(folderPath, fileName);

    //                // 🔥 Köhnə şəkili sil
    //                if (!string.IsNullOrEmpty(trainer.TrainerImgUrl))
    //                {
    //                    var oldImagePath = Path.Combine(
    //                        Directory.GetCurrentDirectory(),
    //                        "wwwroot",
    //                        trainer.TrainerImgUrl.TrimStart('/').Replace("/", Path.DirectorySeparatorChar.ToString())
    //                    );

    //                    if (File.Exists(oldImagePath))
    //                        File.Delete(oldImagePath);
    //                }

    //                // 🔥 Yeni şəkili yaz
    //                using (var stream = new FileStream(fullPath, FileMode.Create))
    //                {
    //                    await request.TrainerImgUrl.CopyToAsync(stream, cancellationToken);
    //                }

    //                imageUrl = "/uploads/trainers/" + fileName;
    //            }

    //            // ✅ 3. Update et
    //            trainer.TrainerNameAndSurname = request.TrainerNameAndSurname;
    //            trainer.TrainerDescription = request.TrainerDescription;
    //            trainer.TrainerTrainingVideoUrl = request.TrainerTrainingVideoUrl;
    //            trainer.TrainerImgUrl = imageUrl;

    //            await _trainerRepository.Update(trainer);

    //            // ✅ 4. Result
    //            var result = new TrainerResult
    //            {
    //                TrainerId = trainer.TrainerId,
    //                TrainerNameAndSurname = trainer.TrainerNameAndSurname,
    //                TrainerDescription = trainer.TrainerDescription,
    //                TrainerTrainingVideoUrl = trainer.TrainerTrainingVideoUrl,
    //                TrainerImgUrl = trainer.TrainerImgUrl
    //            };

    //            return Result.Success(DomainSuccess<TrainerResult>.OK(result));
    //        }
    //    }
    #endregion
    #region old version2 
    //public class UpdateTrainerCommandHandler
    //: IRequestHandler<UpdateTrainerCommand, IResult<DomainSuccess<TrainerResult>, DomainError>>
    //{
    //    private readonly IRepository<Trainer> _trainerRepository;
    //    private readonly ICloudinaryService _cloudinaryService;
    //    private readonly IWebHostEnvironment _env;

    //    public UpdateTrainerCommandHandler(
    //        IRepository<Trainer> trainerRepository,
    //        ICloudinaryService cloudinaryService,
    //        IWebHostEnvironment env)
    //    {
    //        _trainerRepository = trainerRepository;
    //        _cloudinaryService = cloudinaryService;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<TrainerResult>, DomainError>> Handle(
    //        UpdateTrainerCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        var trainer = await _trainerRepository.GetById(request.TrainerId);

    //        if (trainer == null)
    //            return Result.Fail<TrainerResult>(DomainError.NotFound("Trainer not found"));

    //        if (request.TrainerImgUrl != null && request.TrainerImgUrl.Length > 0)
    //        {
    //            if (!string.IsNullOrEmpty(trainer.TrainerImgUrl))
    //            {
    //                await _cloudinaryService.DeleteImageAsync(trainer.TrainerImgUrl);
    //            }

    //            var (url, _, error) = await _cloudinaryService.UploadImageAsync(request.TrainerImgUrl, "trainers");

    //            if (!string.IsNullOrEmpty(error))
    //                return Result.Fail<TrainerResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

    //            trainer.TrainerImgUrl = url;
    //        }


    //        if (request.TrainerVideo != null && request.TrainerVideo.Length > 0)
    //        {
    //            if (!string.IsNullOrEmpty(trainer.TrainerTrainingVideoUrl))
    //            {
    //                var relativeVideoPath = trainer.TrainerTrainingVideoUrl.TrimStart('/');
    //                var oldVideoFullPath = Path.Combine(_env.WebRootPath, relativeVideoPath);

    //                if (File.Exists(oldVideoFullPath))
    //                {
    //                    File.Delete(oldVideoFullPath);
    //                }
    //            }

    //            var extension = Path.GetExtension(request.TrainerVideo.FileName);
    //            var fileName = Guid.NewGuid() + extension;

    //            var folderPath = Path.Combine(_env.WebRootPath, "uploads", "trainers", "videos");

    //            if (!Directory.Exists(folderPath))
    //                Directory.CreateDirectory(folderPath);

    //            var fullPath = Path.Combine(folderPath, fileName);

    //            using (var stream = new FileStream(fullPath, FileMode.Create))
    //            {
    //                await request.TrainerVideo.CopyToAsync(stream, cancellationToken);
    //            }

    //            trainer.TrainerTrainingVideoUrl = "/uploads/trainers/videos/" + fileName;
    //        }

    //        trainer.TrainerNameAndSurname = request.TrainerNameAndSurname;
    //        trainer.TrainerDescription = request.TrainerDescription;

    //        await _trainerRepository.Update(trainer);

    //        var result = new TrainerResult
    //        {
    //            TrainerId = trainer.TrainerId,
    //            TrainerNameAndSurname = trainer.TrainerNameAndSurname,
    //            TrainerDescription = trainer.TrainerDescription,
    //            TrainerTrainingVideoUrl = trainer.TrainerTrainingVideoUrl,
    //            TrainerImgUrl = trainer.TrainerImgUrl!
    //        };

    //        return Result.Success(DomainSuccess<TrainerResult>.OK(result));
    //    }
    //}
    #endregion
    public class UpdateTrainerCommandHandler
        : IRequestHandler<UpdateTrainerCommand, IResult<DomainSuccess<TrainerResult>, DomainError>>
    {
        private readonly IRepository<Trainer> _trainerRepository;
        private readonly ICloudinaryService _cloudinaryService;

        public UpdateTrainerCommandHandler(
            IRepository<Trainer> trainerRepository,
            ICloudinaryService cloudinaryService)
        {
            _trainerRepository = trainerRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<TrainerResult>, DomainError>> Handle(
            UpdateTrainerCommand request,
            CancellationToken cancellationToken)
        {
            var trainer = await _trainerRepository.GetById(request.TrainerId);

            if (trainer == null)
                return Result.Fail<TrainerResult>(DomainError.NotFound("Trainer not found"));

            string? newImageUrl = null;
            string? newVideoUrl = null;

            string? oldImageUrl = trainer.TrainerImgUrl;
            string? oldVideoUrl = trainer.TrainerTrainingVideoUrl;

            try
            {
                if (request.TrainerImgUrl != null && request.TrainerImgUrl.Length > 0)
                {
                    var (url, _, error) = await _cloudinaryService.UploadImageAsync(request.TrainerImgUrl, "trainers/images");

                    if (!string.IsNullOrEmpty(error))
                        return Result.Fail<TrainerResult>(DomainError.BadRequest($"Cloudinary image error: {error}"));

                    newImageUrl = url;
                }

                if (request.TrainerVideo != null && request.TrainerVideo.Length > 0)
                {
                    var (url, _, error) = await _cloudinaryService.UploadVideoAsync(request.TrainerVideo, "trainers/videos");

                    if (!string.IsNullOrEmpty(error))
                    {
                        if (!string.IsNullOrEmpty(newImageUrl))
                            await _cloudinaryService.DeleteImageAsync(newImageUrl);

                        return Result.Fail<TrainerResult>(DomainError.BadRequest($"Cloudinary video error: {error}"));
                    }

                    newVideoUrl = url;
                }

                if (!string.IsNullOrEmpty(newImageUrl) && !string.IsNullOrEmpty(oldImageUrl))
                {
                    await _cloudinaryService.DeleteImageAsync(oldImageUrl);
                }

                if (!string.IsNullOrEmpty(newVideoUrl) && !string.IsNullOrEmpty(oldVideoUrl))
                {
                    await _cloudinaryService.DeleteVideoAsync(oldVideoUrl);
                }

                trainer.TrainerNameAndSurname = request.TrainerNameAndSurname;
                trainer.TrainerDescription = request.TrainerDescription;
                trainer.TrainerPosition = request.TrainerPosition;

                if (!string.IsNullOrEmpty(newImageUrl))
                    trainer.TrainerImgUrl = newImageUrl;

                if (!string.IsNullOrEmpty(newVideoUrl))
                    trainer.TrainerTrainingVideoUrl = newVideoUrl;

                await _trainerRepository.Update(trainer);

                var result = new TrainerResult
                {
                    TrainerId = trainer.TrainerId,
                    TrainerNameAndSurname = trainer.TrainerNameAndSurname,
                    TrainerPosition = trainer.TrainerPosition,
                    TrainerDescription = trainer.TrainerDescription,
                    TrainerTrainingVideoUrl = trainer.TrainerTrainingVideoUrl,
                    TrainerImgUrl = trainer.TrainerImgUrl!
                };

                return Result.Success(DomainSuccess<TrainerResult>.OK(result));
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(newImageUrl))
                    await _cloudinaryService.DeleteImageAsync(newImageUrl);

                if (!string.IsNullOrEmpty(newVideoUrl))
                    await _cloudinaryService.DeleteVideoAsync(newVideoUrl);

                return Result.Fail<TrainerResult>(DomainError.BadRequest($"Unexpected error: {ex.Message}"));
            }
        }
    }
}
