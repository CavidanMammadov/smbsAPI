using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.MissionAndVisions;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.MissionAndVisions
{
    public class DeleteMissionAndVisionCommandHandler(IRepository<MissionAndVision> repository) : IRequestHandler<DeleteMissionAndVisionCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteMissionAndVisionCommand request, CancellationToken cancellationToken)
        {
            var value=await repository.GetById(request.Id);
            if (value == null) {
                return Result.Fail<int>(DomainError.NotFound("Cant be found"));
            }
           await repository.Delete(value!);
            return Result.Success<int>(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
