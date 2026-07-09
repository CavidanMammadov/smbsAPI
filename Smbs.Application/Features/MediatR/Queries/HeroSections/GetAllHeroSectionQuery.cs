using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.HeroSections;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.HeroSections
{
    public class GetAllHeroSectionQuery:IRequest<IResult<DomainSuccess<List<ResultHeroSectionDto>>,DomainError>>
    {
    }
}
