using MediatR;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Results;
using System.Collections.Generic;

namespace Smbs.Application.Features.MediatR.Queries.Advice
{
    public class  GetAllAdviceQuery : IRequest<IResult<DomainSuccess<List<GetAllAdviceResult>>, DomainError>>
    {
    }
}
