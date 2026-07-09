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
    public class GetTrainingProgramByIdQueryHandler(IRepository<TrainingProgram> repository) : IRequestHandler<GetTrainingProgramByIdQuery, IResult<DomainSuccess<TrainingProgramResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<TrainingProgramResult>, DomainError>> Handle(GetTrainingProgramByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<TrainingProgramResult>(DomainError.NotFound("Training program not found"));
            }
            else
            {
                var trainingProgram = new TrainingProgramResult
                {TrainingProgramId = result.TrainingProgramId,
                    TrainingProgramDescription = result.TrainingProgramDescription,
                    TrainingProgramTitle = result.TrainingProgramTitle,
                    TrainingProgramTrainerId = result.TrainingProgramTrainerId
                };
                return Result.Success<TrainingProgramResult>(DomainSuccess<TrainingProgramResult>.OK(trainingProgram));
            }
        }
    }
}
