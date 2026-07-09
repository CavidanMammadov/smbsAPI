using MediatR;
using Smbs.Application.Features.MediatR.Queries.Advice;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Advice
{
    public class GetByIdAdviceQueryHandler : IRequestHandler<GetByIdAdviceQuery, IResult<DomainSuccess<GetByIdAdviceResult>, DomainError>>
    {
        private readonly IRepository<Smbs.Domain.Entities.Advice> _repository;

        public GetByIdAdviceQueryHandler(IRepository<Smbs.Domain.Entities.Advice> repository)
        {
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<GetByIdAdviceResult>, DomainError>> Handle(GetByIdAdviceQuery request, CancellationToken cancellationToken)
        {
            var advice = await _repository.GetById(request.AdviceId);
            if (advice == null)
            {
                return Result.Fail<GetByIdAdviceResult>(
                    DomainError.NotFound("Advice not found."));
            }

            var result = new GetByIdAdviceResult
            {
                AdviceId = advice.AdviceId,
                AdviceTitle = advice.AdviceTitle,
                AdviceImage = advice.AdviceImage,
                AdviceDescription = advice.AdviceDescription,
                AdviceContent = advice.AdviceContent,
                AdviceCreated = advice.AdviceCreated,
                AdviceDuration = advice.AdviceDuration
            };

            return Result.Success(DomainSuccess<GetByIdAdviceResult>.OK(result, "Advice retrieved successfully."));
        }
    }
}
