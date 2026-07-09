using MediatR;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Commands.Advice
{
    public class DeleteAdviceCommand : IRequest<IResult<DomainSuccess<int>, DomainError>>
    {
        public int AdviceId { get; set; }

        public DeleteAdviceCommand(int adviceId)
        {
            AdviceId = adviceId;
        }
    }
}
