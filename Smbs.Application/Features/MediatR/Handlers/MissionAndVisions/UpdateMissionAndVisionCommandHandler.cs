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
    public class UpdateMissionAndVisionCommandHandler(IRepository<MissionAndVision> repository) : IRequestHandler<UpdateMissionAndVisionCommand, IResult<DomainSuccess<MissionAndVisionResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MissionAndVisionResult>, DomainError>> Handle(UpdateMissionAndVisionCommand request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.MissionAndVisionId);
            if (value == null) {
                return Result.Fail<MissionAndVisionResult>(DomainError.NotFound("Not found in given id"));
            }
          value.MissionAndVisionContent = request.MissionAndVisionContent;
            value.MissionAndVisionTitle = request.MissionAndVisionTitle;
            await repository.Update(value);
            return Result.Success<MissionAndVisionResult>(DomainSuccess<MissionAndVisionResult>.OK(new MissionAndVisionResult {
                MissionAndVisionId = request.MissionAndVisionId,
                MissionAndVisionTitle = request.MissionAndVisionTitle,
                MissionAndVisionContent = request.MissionAndVisionContent,
                
            }, "Updated successfully"));
        }
    }
}
