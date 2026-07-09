using MediatR;
using Smbs.Application.Features.MediatR.Results.AdviceTitles;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.AdviceTitles
{
    public class GetByIdAdviceTitleQuery:IRequest<IResult<DomainSuccess<AdviceTitleResult>, DomainError>>
    {
        public int Id { get; set; }

        public GetByIdAdviceTitleQuery(int id)
        {
            Id = id;
        }
    }
}
