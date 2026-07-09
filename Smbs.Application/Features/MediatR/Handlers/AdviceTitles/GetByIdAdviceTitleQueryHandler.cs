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
    public class GetByIdAdviceTitleQueryHandler(IRepository<AdviceTitle> repository) : IRequestHandler<GetByIdAdviceTitleQuery, IResult<DomainSuccess<AdviceTitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceTitleResult>, DomainError>> Handle(GetByIdAdviceTitleQuery request, CancellationToken cancellationToken)
        {
            var result=await repository.GetById(request.Id);
            if (result==null)
            {
                return Result.Fail<AdviceTitleResult>(DomainError.NotFound($"Advice title with id {request.Id} not found"));
            }
            else
            {
                return Result.Success<AdviceTitleResult>(DomainSuccess<AdviceTitleResult>.OK(new AdviceTitleResult
                {
                    AdviceTitleId = result.AdviceTitleId,
                    AdviceTitleContent = result.AdviceTitleContent,
                    AdviceTitleAdviceId = result.AdviceTitleAdviceId
                }));

            }
        }
    }
}
