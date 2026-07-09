using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Trainings;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    #region old version
    //public class CreateTrainingCommandHandler
    //: IRequestHandler<CreateTrainingCommand, IResult<DomainSuccess<TrainingResult>, DomainError>>
    //{
    //    private readonly IRepository<Training> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public CreateTrainingCommandHandler(IRepository<Training> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<TrainingResult>, DomainError>> Handle(
    //        CreateTrainingCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 🔹 1. Image validation
    //        if (request.TrainingImage == null || request.TrainingImage.Length == 0)
    //            return Result.Fail<TrainingResult>(DomainError.BadRequest("Training image is required"));

    //        // 🔹 2. Save image to wwwroot/uploads
    //        var fileName = Guid.NewGuid() + Path.GetExtension(request.TrainingImage.FileName);
    //        var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "trainings");

    //        if (!Directory.Exists(uploadPath))
    //            Directory.CreateDirectory(uploadPath);

    //        var filePath = Path.Combine(uploadPath, fileName);

    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await request.TrainingImage.CopyToAsync(stream, cancellationToken);
    //        }

    //        // 🔹 3. Create Training entity
    //        var training = new Training
    //        {
    //            TrainingTitle = request.TrainingTitle,
    //            TrainingDescription = request.TrainingDescription,
    //            TrainingImage = fileName, // DB-də yalnız ad saxlanılır
    //            TrainingDuration = request.TrainingDuration,
    //            TrainingGroupSize = request.TrainingGroupSize,
    //            TrainingLanguage = request.TrainingLanguage,
    //            TrainingAbout = request.TrainingAbout,
    //            TrainingCoveredTopics = request.TrainingCoveredTopics,
    //            TrainingSchedule = request.TrainingSchedule,
    //            TrainingAddress = request.TrainingAddress,
    //            TrainingWorkOpportunity = request.TrainingWorkOpportunity,
    //            TrainingFormat = request.TrainingFormat,
    //            TrainingPrice = request.TrainingPrice,
    //            TrainingTeacherCertificate = request.TrainingTeacherCertificate,
    //            TrainingTeacher = request.TrainingTeacher
    //        };

    //        // 🔹 4. Save to DB
    //        await _repository.Create(training);

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
    //            TrainingPrice = training.TrainingPrice,
    //            TrainingFormat = training.TrainingFormat,
    //            TrainingTeacher = training.TrainingTeacher,
    //            TrainingTeacherCertificate = training.TrainingTeacherCertificate
    //        };

    //        return Result.Success(DomainSuccess<TrainingResult>.Created(dto, "Training created"));
    //    }
    //}
    #endregion
    public class CreateTrainingCommandHandler
   : IRequestHandler<CreateTrainingCommand, IResult<DomainSuccess<TrainingResult>, DomainError>>
    {
        private readonly ITrainingRepository _repository;
        private readonly ICloudinaryService _cloudinaryService; 

        public CreateTrainingCommandHandler(ITrainingRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<TrainingResult>, DomainError>> Handle(
            CreateTrainingCommand request,
            CancellationToken cancellationToken)
        {
            if (request.TrainingImage == null || request.TrainingImage.Length == 0)
                return Result.Fail<TrainingResult>(DomainError.BadRequest("Training image is required"));

            var (imageUrl, _, error) = await _cloudinaryService.UploadImageAsync(request.TrainingImage, "trainings");

            if (!string.IsNullOrEmpty(error))
                return Result.Fail<TrainingResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

            var training = new Training
            {
                TrainingTitle = request.TrainingTitle,
                TrainingDescription = request.TrainingDescription,
                TrainingImage = imageUrl!, 
                TrainingDuration = request.TrainingDuration,
                TrainingGroupSize = request.TrainingGroupSize,
                TrainingLanguage = request.TrainingLanguage,
                TrainingAbout = request.TrainingAbout,
                TrainingCoveredTopics = request.TrainingCoveredTopics,
                TrainingSchedule = request.TrainingSchedule,
                TrainingAddress = request.TrainingAddress,
                TrainingWorkOpportunity = request.TrainingWorkOpportunity,
                TrainingFormat = request.TrainingFormat,
                TrainingPrice = request.TrainingPrice,
                TrainingTeacherCertificate = request.TrainingTeacherCertificate,
                TrainingTeacher = request.TrainingTeacher,
                TrainingAudienceType = request.TrainingAudienceType
            };

            await _repository.Create(training);

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
                TrainingPrice = training.TrainingPrice,
                TrainingFormat = training.TrainingFormat,
                TrainingTeacher = training.TrainingTeacher,
                TrainingTeacherCertificate = training.TrainingTeacherCertificate,
                TrainingAudienceType = training.TrainingAudienceType
            };

            return Result.Success(DomainSuccess<TrainingResult>.Created(dto, "Training created"));
        }
    }
}
