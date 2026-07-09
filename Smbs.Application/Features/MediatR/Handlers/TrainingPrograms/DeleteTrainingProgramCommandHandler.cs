using MediatR;
using Smbs.Application.Features.MediatR.Commands.TrainingPrograms;
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
    public class DeleteTrainingProgramCommandHandler(IRepository<TrainingProgram> repository) : IRequestHandler<DeleteTrainingProgramCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteTrainingProgramCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            if(result==null)
            {
                return Result.Fail<int>(DomainError.NotFound("Training program not found"));
            }
            await repository.Delete(result);
            return Result.Success<int>(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
