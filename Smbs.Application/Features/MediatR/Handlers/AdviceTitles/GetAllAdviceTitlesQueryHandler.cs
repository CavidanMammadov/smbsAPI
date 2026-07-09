using MediatR;
using Smbs.Application.Features.MediatR.Queries.AdviceTitles;
using Smbs.Application.Features.MediatR.Results.AdviceTitles;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.AdviceTitles
{
    public class GetAllAdviceTitlesQueryHandler(IRepository<AdviceTitle> repository) : IRequestHandler<GetAllAdviceTitlesQuery, IResult<DomainSuccess<List<AdviceTitleResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<AdviceTitleResult>>, DomainError>> Handle(GetAllAdviceTitlesQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<AdviceTitleResult>>(DomainError.NotFound("No advice titles found"));
            }
            else
            {
                var adviceTitleResults = result.Select(at => new AdviceTitleResult
                {
                    AdviceTitleId = at.AdviceTitleId,
                    AdviceTitleContent = at.AdviceTitleContent,
                    AdviceTitleAdviceId = at.AdviceTitleAdviceId
                }).ToList();
                return Result.Success(DomainSuccess<List<AdviceTitleResult>>.OK(adviceTitleResults));
            }
        }
    }
}
