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
    public class GetAllMissionAndVisionCommandHandler(IRepository<MissionAndVision> repository) : IRequestHandler<GetAllMissionAndVisionQuery, IResult<DomainSuccess<List<MissionAndVisionResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<MissionAndVisionResult>>, DomainError>> Handle(GetAllMissionAndVisionQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<MissionAndVisionResult>>(DomainError.NotFound("Not found"));
            }
            return Result.Success<List<MissionAndVisionResult>>(DomainSuccess<List<MissionAndVisionResult>>.OK(result.Select(a => new MissionAndVisionResult
            {
                MissionAndVisionId = a.MissionAndVisionId,
                MissionAndVisionContent = a.MissionAndVisionContent,
               
                MissionAndVisionTitle = a.MissionAndVisionTitle
            }).ToList()));
        }
    }
}
