using MediatR;
using Smbs.Application.Features.MediatR.Queries.Advice;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Advice
{
    public class GetAllAdviceQueryHandler : IRequestHandler<GetAllAdviceQuery        , IResult<DomainSuccess<List<GetAllAdviceResult>>, DomainError>>
    {       
        private readonly IRepository<Smbs.Domain.Entities.Advice> _repository;

        public GetAllAdviceQueryHandler(IRepository<Smbs.Domain.Entities.Advice> repository)
        {
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<List<GetAllAdviceResult>>, DomainError>> Handle(GetAllAdviceQuery request, CancellationToken cancellationToken)
        {
            var adviceList = await _repository.GetAll();

            if (adviceList == null || !adviceList.Any())
            {
                return Result.Fail<List<GetAllAdviceResult>>(DomainError.NotFound("No advice records found."));
            }

            var result = adviceList.Select(advice => new GetAllAdviceResult
            {
                AdviceId = advice.AdviceId,
                Title = advice.AdviceTitle,
                Image = advice.AdviceImage,
                Description = advice.AdviceDescription,
                Content = advice.AdviceContent,
                Created = advice.AdviceCreated,
                Duration = advice.AdviceDuration
            }).ToList();

            return Result.Success(DomainSuccess<List<GetAllAdviceResult>>.OK(result, "Advice records retrieved successfully."));
        }
    }
}
