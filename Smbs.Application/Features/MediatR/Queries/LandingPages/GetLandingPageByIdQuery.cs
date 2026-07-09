using MediatR;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.LandingPages
{
    public class GetLandingPageByIdQuery:IRequest<IResult<DomainSuccess<LandingPageResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetLandingPageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
