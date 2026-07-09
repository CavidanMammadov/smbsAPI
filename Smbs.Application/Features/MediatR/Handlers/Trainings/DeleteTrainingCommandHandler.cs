using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Trainings;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    #region old vers
    //public class DeleteTrainingCommandHandler(IRepository<Training> repository) : IRequestHandler<DeleteTrainingCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
    //    {
    //        var result = await repository.GetById(request.Id);
    //        if (result == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound("Cant be found"));
    //        }
    //        await repository.Delete(result);
    //        return Result.Success<int>(DomainSuccess<int>.OK(result.TrainingId, "Deleted successfully"));
    //    }
    //}
    #endregion
    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly IRepository<Training> _repository;
        private readonly ICloudinaryService _cloudinaryService; 

        public DeleteTrainingCommandHandler(IRepository<Training> repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
  
            var result = await _repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Cant be found"));
            }

            if (!string.IsNullOrEmpty(result.TrainingImage))
            {
                await _cloudinaryService.DeleteImageAsync(result.TrainingImage);
            }

            await _repository.Delete(result);

            return Result.Success<int>(DomainSuccess<int>.OK(result.TrainingId, "Deleted successfully"));
        }
    }
}
