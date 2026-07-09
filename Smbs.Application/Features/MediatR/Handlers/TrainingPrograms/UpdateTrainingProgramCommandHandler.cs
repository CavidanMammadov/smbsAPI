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
    public class UpdateTrainingProgramCommandHandler(IRepository<TrainingProgram> repository) : IRequestHandler<UpdateTrainingProgramCommand, IResult<DomainSuccess<TrainingProgramResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<TrainingProgramResult>, DomainError>> Handle(UpdateTrainingProgramCommand request, CancellationToken cancellationToken)
        {
            var result= await repository.GetById(request.TrainingProgramId);
            if(result == null)
            {
                return Result.Fail<TrainingProgramResult>(DomainError.NotFound("Training program not found"));
            }
            result.TrainingProgramDescription = request.TrainingProgramDescription;
            result.TrainingProgramTitle = request.TrainingProgramTitle;
            result.TrainingProgramTrainerId = request.TrainingProgramTrainerId;
            await repository.Update(result);
         
            return Result.Success<TrainingProgramResult>(DomainSuccess<TrainingProgramResult>.OK(new TrainingProgramResult
            {
                TrainingProgramId = request.TrainingProgramId,
                TrainingProgramDescription = request.TrainingProgramDescription,
                TrainingProgramTitle = request.TrainingProgramTitle,
                TrainingProgramTrainerId = request.TrainingProgramTrainerId
            },"Updated successfully"));
        }
    }
}
