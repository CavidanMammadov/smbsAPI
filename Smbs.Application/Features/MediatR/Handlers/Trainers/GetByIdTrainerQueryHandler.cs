using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainers
{
    public class GetByIdTrainerQueryHandler(ITrainerRespository repository) : IRequestHandler<GetByIdTrainerQuery, IResult<DomainSuccess<TrainerResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<TrainerResult>, DomainError>> Handle(GetByIdTrainerQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<TrainerResult>(DomainError.NotFound("No trainer found with this id"));
            }
            return Result.Success(DomainSuccess<TrainerResult>.OK(new TrainerResult
            {
                TrainerId = value.TrainerId,
                TrainerNameAndSurname = value.TrainerNameAndSurname,
                TrainerPosition = value.TrainerPosition,
                TrainerDescription = value.TrainerDescription,
                TrainerTrainingVideoUrl = value.TrainerTrainingVideoUrl,
                TrainerTrainingPrograms = value.TrainerTrainingPrograms,
                TrainerImgUrl = value.TrainerImgUrl
            }, "Trainer retrieved successfully"));
        }
    }
}
