using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainers
{
    public class GetAllTrainersQueryHandler(ITrainerRespository repository) : IRequestHandler<GetAllTrainersQuery, IResult<DomainSuccess<List<TrainerResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<TrainerResult>>, DomainError>> Handle(GetAllTrainersQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<TrainerResult>>(DomainError.NotFound("No trainers found"));
            }
            return Result.Success(DomainSuccess<List<TrainerResult>>.OK(result.Select(x => new TrainerResult
            {
                TrainerId = x.TrainerId,
                TrainerDescription = x.TrainerDescription,
                TrainerPosition = x.TrainerPosition,
                TrainerNameAndSurname = x.TrainerNameAndSurname,
                TrainerTrainingPrograms = x.TrainerTrainingPrograms,
                TrainerTrainingVideoUrl = x.TrainerTrainingVideoUrl,
                
                TrainerImgUrl = x.TrainerImgUrl
            }).ToList(), "Trainers retrieved successfully"));
        }
    }
}
