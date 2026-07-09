using MediatR;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Advice
{
    public class GetByIdAdviceQuery : IRequest<IResult<DomainSuccess<GetByIdAdviceResult>, DomainError>>
    {
        public int AdviceId { get; set; }

        public GetByIdAdviceQuery(int adviceId)
        {
            AdviceId = adviceId;
        }
    }
}
