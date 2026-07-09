using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.MissionAndVisions;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.MissionAndVisions
{
    public class GetAllMissionAndVisionQuery:IRequest<IResult<DomainSuccess<List<MissionAndVisionResult>>,DomainError>>
    {
    }
}
