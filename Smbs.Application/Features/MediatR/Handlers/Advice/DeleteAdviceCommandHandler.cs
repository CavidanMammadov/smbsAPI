using MediatR;
using Smbs.Application.Features.MediatR.Commands.Advice;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Advice
{
    public class DeleteAdviceCommandHandler : IRequestHandler<DeleteAdviceCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly IRepository<Smbs.Domain.Entities.Advice> _repository;

        public DeleteAdviceCommandHandler(IRepository<Smbs.Domain.Entities.Advice> repository)
        {
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteAdviceCommand request, CancellationToken cancellationToken)
        {
            var advice = await _repository.GetById(request.AdviceId);
            if (advice == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Advice not found."));
            }

            await _repository.Delete(advice);

            return Result.Success(DomainSuccess<int>.OK(request.AdviceId, "Advice deleted successfully."));
        }
    }
}
