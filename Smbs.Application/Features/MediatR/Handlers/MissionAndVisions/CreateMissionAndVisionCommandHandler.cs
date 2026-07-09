using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.MissionAndVisions;
using Smbs.Application.Features.MediatR.Results.MissionAndVisions;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.MissionANdVisions
{
    public class CreateMissionAndVisionCommandHandler(IRepository<MissionAndVision> repository) : IRequestHandler<CreateMissionAndVisionCommand, IResult<DomainSuccess<MissionAndVisionResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MissionAndVisionResult>, DomainError>> Handle(CreateMissionAndVisionCommand request, CancellationToken cancellationToken)
        { var result = new MissionAndVision
        {
            MissionAndVisionContent = request.MissionAndVisionContent,
          
            MissionAndVisionTitle = request.MissionAndVisionTitle,
        };
            await repository.Create(result);
            return Result.Success<MissionAndVisionResult>(DomainSuccess<MissionAndVisionResult>.Created(new MissionAndVisionResult
            {MissionAndVisionId=result.MissionAndVisionId,
                MissionAndVisionContent = request.MissionAndVisionContent,
                MissionAndVisionTitle = request.MissionAndVisionTitle,
             
            },"Created successfully"));
        }
    }
}
