using MediatR;
using Smbs.Application.Features.MediatR.Queries.TrainingPrograms;
using Smbs.Application.Features.MediatR.Results.TrainingPrograms;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.TrainingPrograms
{
    public class GetAllTrainingProgramsQueryHandler(IRepository<TrainingProgram> repository) : IRequestHandler<GetAllTrainingProgramsQuery, IResult<DomainSuccess<List<TrainingProgramResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<TrainingProgramResult>>, DomainError>> Handle(GetAllTrainingProgramsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<TrainingProgramResult>>(DomainError.NotFound("No training programs found"));
            }
            else
            {
                var trainingPrograms = result.Select(tp => new TrainingProgramResult
                {
                    TrainingProgramId = tp.TrainingProgramId,
                    TrainingProgramDescription = tp.TrainingProgramDescription,
                    TrainingProgramTitle = tp.TrainingProgramTitle,
                    TrainingProgramTrainerId = tp.TrainingProgramTrainerId
                }).ToList();
                return Result.Success<List<TrainingProgramResult>>(DomainSuccess<List<TrainingProgramResult>>.OK(trainingPrograms));
            }
        }
    }
}
