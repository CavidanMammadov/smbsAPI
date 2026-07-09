using MediatR;
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
    public class GetByIdHeroSectionQuery:IRequest<IResult<DomainSuccess<ResultHeroSectionDto>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdHeroSectionQuery(int id)
        {
            Id = id;
        }
    }
}
