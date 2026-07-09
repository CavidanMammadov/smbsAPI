using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Trainings;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;


namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    #region old vers
    //public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, IResult<DomainSuccess<TrainingResult>, DomainError>>
    //{
    //    private readonly IRepository<Training> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public UpdateTrainingCommandHandler(IRepository<Training> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<TrainingResult>, DomainError>> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
    //    {
    //        // 🔹 1. Mövcud training-i tap
    //        var training = await _repository.GetById(request.TrainingId);
    //        if (training == null)
    //            return Result.Fail<TrainingResult>(DomainError.NotFound("Training not found"));

    //        // 🔹 2. Əgər yeni image varsa, köhnəni sil və yenisini save et
    //        if (request.TrainingImage != null && request.TrainingImage.Length > 0)
    //        {
    //            // Köhnə faylı sil
    //            if (!string.IsNullOrEmpty(training.TrainingImage))
    //            {
    //                var oldPath = Path.Combine(_env.WebRootPath, "uploads", "trainings", training.TrainingImage);
    //                if (File.Exists(oldPath))
    //                    File.Delete(oldPath);
    //            }

    //            // Yeni faylı saxla
    //            var fileName = Guid.NewGuid() + Path.GetExtension(request.TrainingImage.FileName);
    //            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "trainings");
    //            if (!Directory.Exists(uploadPath))
    //                Directory.CreateDirectory(uploadPath);

    //            var filePath = Path.Combine(uploadPath, fileName);
    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await request.TrainingImage.CopyToAsync(stream, cancellationToken);
    //            }

    //            training.TrainingImage = fileName;
    //        }

    //        // 🔹 3. Digər fields update et
    //        training.TrainingTitle = request.TrainingTitle;
    //        training.TrainingDescription = request.TrainingDescription;
    //        training.TrainingDuration = request.TrainingDuration;
    //        training.TrainingGroupSize = request.TrainingGroupSize;
    //        training.TrainingLanguage = request.TrainingLanguage;
    //        training.TrainingAbout = request.TrainingAbout;
    //        training.TrainingCoveredTopics = request.TrainingCoveredTopics;
    //        training.TrainingSchedule = request.TrainingSchedule;
    //        training.TrainingAddress = request.TrainingAddress;
    //        training.TrainingWorkOpportunity = request.TrainingWorkOpportunity;
    //        training.TrainingFormat = request.TrainingFormat;
    //        training.TrainingPrice = request.TrainingPrice;

    //        // 🔹 4. DB update
    //        await _repository.Update(training);

    //        // 🔹 5. Response DTO
    //        var dto = new TrainingResult
    //        {
    //            TrainingId = training.TrainingId,
    //            TrainingTitle = training.TrainingTitle,
    //            TrainingDescription = training.TrainingDescription,
    //            TrainingImage = training.TrainingImage,
    //            TrainingDuration = training.TrainingDuration,
    //            TrainingGroupSize = training.TrainingGroupSize,
    //            TrainingLanguage = training.TrainingLanguage,
    //            TrainingAbout = training.TrainingAbout,
    //            TrainingCoveredTopics = training.TrainingCoveredTopics,
    //            TrainingSchedule = training.TrainingSchedule,
    //            TrainingAddress = training.TrainingAddress,
    //            TrainingWorkOpportunity = training.TrainingWorkOpportunity,
    //            TrainingFormat = training.TrainingFormat,
    //            TrainingPrice = training.TrainingPrice
    //        };

    //        return Result.Success(DomainSuccess<TrainingResult>.OK(dto, "Training updated"));
    //    }
    //}
    #endregion
    public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, IResult<DomainSuccess<TrainingResult>, DomainError>>
    {
        private readonly ITrainingRepository _repository;
        private readonly ICloudinaryService _cloudinaryService; 

        public UpdateTrainingCommandHandler(ITrainingRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<TrainingResult>, DomainError>> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
        {
            var training = await _repository.GetById(request.TrainingId);
            if (training == null)
                return Result.Fail<TrainingResult>(DomainError.NotFound("Training not found"));

            if (request.TrainingImage != null && request.TrainingImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(training.TrainingImage))
                {
                    await _cloudinaryService.DeleteImageAsync(training.TrainingImage);
                }

                var (url, _, error) = await _cloudinaryService.UploadImageAsync(request.TrainingImage, "trainings");

                if (!string.IsNullOrEmpty(error))
                    return Result.Fail<TrainingResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

                training.TrainingImage = url;
            }

            training.TrainingTitle = request.TrainingTitle;
            training.TrainingDescription = request.TrainingDescription;
            training.TrainingDuration = request.TrainingDuration;
            training.TrainingGroupSize = request.TrainingGroupSize;
            training.TrainingLanguage = request.TrainingLanguage;
            training.TrainingAbout = request.TrainingAbout;
            training.TrainingCoveredTopics = request.TrainingCoveredTopics;
            training.TrainingSchedule = request.TrainingSchedule;
            training.TrainingAddress = request.TrainingAddress;
            training.TrainingWorkOpportunity = request.TrainingWorkOpportunity;
            training.TrainingFormat = request.TrainingFormat;
            training.TrainingPrice = request.TrainingPrice;
            training.TrainingTeacher = request.TrainingTeacher;
            training.TrainingTeacherCertificate = request.TrainingTeacherCertificate;
            training.TrainingAudienceType = request.TrainingAudienceType;

            await _repository.Update(training);

            var dto = new TrainingResult
            {
                TrainingId = training.TrainingId,
                TrainingTitle = training.TrainingTitle,
                TrainingDescription = training.TrainingDescription,
                TrainingImage = training.TrainingImage,
                TrainingDuration = training.TrainingDuration,
                TrainingGroupSize = training.TrainingGroupSize,
                TrainingLanguage = training.TrainingLanguage,
                TrainingAbout = training.TrainingAbout,
                TrainingCoveredTopics = training.TrainingCoveredTopics,
                TrainingSchedule = training.TrainingSchedule,
                TrainingAddress = training.TrainingAddress,
                TrainingWorkOpportunity = training.TrainingWorkOpportunity,
                TrainingFormat = training.TrainingFormat,
                TrainingPrice = training.TrainingPrice,
                TrainingTeacher = training.TrainingTeacher,
                TrainingTeacherCertificate = training.TrainingTeacherCertificate,
                TrainingAudienceType = training.TrainingAudienceType
            };

            return Result.Success(DomainSuccess<TrainingResult>.OK(dto, "Training updated"));
        }
    }
}
