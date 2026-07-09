using MediatR;
using Smbs.Application.Features.MediatR.Commands.TrainingPrograms;
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
    public class CreateTrainingProgramCommandHandler(IRepository<TrainingProgram> repository) : IRequestHandler<CreateTrainingProgramCommand, IResult<DomainSuccess<TrainingProgramResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<TrainingProgramResult>, DomainError>> Handle(CreateTrainingProgramCommand request, CancellationToken cancellationToken)
        {
            var program = new TrainingProgram
            {
                TrainingProgramDescription = request.TrainingProgramDescription,
                TrainingProgramTitle = request.TrainingProgramTitle,
                TrainingProgramTrainerId = request.TrainingProgramTrainerId

            };
           await repository.Create(program);
            return Result.Success<TrainingProgramResult>(DomainSuccess<TrainingProgramResult>.Created(new TrainingProgramResult
            {
                TrainingProgramId = program.TrainingProgramId,
                TrainingProgramDescription = request.TrainingProgramDescription,
                TrainingProgramTitle = request.TrainingProgramTitle,
                TrainingProgramTrainerId = request.TrainingProgramTrainerId
            }));
        }
    }
}
