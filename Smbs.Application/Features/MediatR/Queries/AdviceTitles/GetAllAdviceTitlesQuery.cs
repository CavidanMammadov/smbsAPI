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
    public class GetAllAdviceTitlesQuery:IRequest<IResult<DomainSuccess<List<AdviceTitleResult>>, DomainError>>
    {
    }
}
