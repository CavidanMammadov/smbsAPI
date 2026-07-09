using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Trainers;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;


namespace Smbs.Application.Features.MediatR.Handlers.Trainers
{
    #region old version
    //public class DeleteTrainerCommandHandler(IRepository<Trainer> repository) : IRequestHandler<DeleteTrainerCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    //    {
    //        var user = await repository.GetById(request.Id);
    //        if (user == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound("Cant be found in this id"));
    //        }
    //        await repository.Delete(user);
    //        return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
    //    }
    //}
    #endregion
    #region old version 2
    //public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    private readonly ITrainerRespository _repository;
    //    private readonly ICloudinaryService _cloudinaryService;
    //    private readonly IWebHostEnvironment _env; 

    //    public DeleteTrainerCommandHandler(
    //        ITrainerRespository repository,
    //        ICloudinaryService cloudinaryService,
    //        IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _cloudinaryService = cloudinaryService;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    //    {
    //        var trainer = await _repository.GetById(request.Id);
    //        if (trainer == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound("Cant be found in this id"));
    //        }

    //        if (!string.IsNullOrEmpty(trainer.TrainerImgUrl))
    //        {
    //            await _cloudinaryService.DeleteImageAsync(trainer.TrainerImgUrl);
    //        }

    //        if (!string.IsNullOrEmpty(trainer.TrainerTrainingVideoUrl))
    //        {
    //            var relativeVideoPath = trainer.TrainerTrainingVideoUrl.TrimStart('/');

    //            var fullVideoPath = Path.Combine(_env.WebRootPath, relativeVideoPath);

    //            if (File.Exists(fullVideoPath))
    //            {
    //                File.Delete(fullVideoPath);
    //            }
    //        }

    //        await _repository.Delete(trainer);

    //        return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
    //    }
    //}
    #endregion
    public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly ITrainerRespository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public DeleteTrainerCommandHandler(
            ITrainerRespository repository,
            ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = await _repository.GetById(request.Id);
            if (trainer == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Cant be found in this id"));
            }

            if (!string.IsNullOrEmpty(trainer.TrainerImgUrl))
            {
                await _cloudinaryService.DeleteImageAsync(trainer.TrainerImgUrl);
            }

            if (!string.IsNullOrEmpty(trainer.TrainerTrainingVideoUrl))
            {
                await _cloudinaryService.DeleteVideoAsync(trainer.TrainerTrainingVideoUrl);
            }

            await _repository.Delete(trainer);

            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
