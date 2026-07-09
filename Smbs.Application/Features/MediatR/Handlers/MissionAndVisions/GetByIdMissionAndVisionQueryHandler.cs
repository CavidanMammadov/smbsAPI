using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.MissionAndVisions;
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

namespace Smbs.Application.Features.MediatR.Handlers.MissionAndVisions
{
    public class GetByIdMissionAndVisionQueryHandler(IRepository<MissionAndVision> repository) : IRequestHandler<GetByIdMissionAndVisionQuery, IResult<DomainSuccess<MissionAndVisionResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MissionAndVisionResult>, DomainError>> Handle(GetByIdMissionAndVisionQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<MissionAndVisionResult>(DomainError.NotFound("Not found"));
            }
            return Result.Success<MissionAndVisionResult>(DomainSuccess<MissionAndVisionResult>.OK(new MissionAndVisionResult
            {
                MissionAndVisionId = value.MissionAndVisionId,
                MissionAndVisionContent = value.MissionAndVisionContent,
          
                MissionAndVisionTitle = value.MissionAndVisionTitle
            }, "found successfully"));
        }
    }
}
