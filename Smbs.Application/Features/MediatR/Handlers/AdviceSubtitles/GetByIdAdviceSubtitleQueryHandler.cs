using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.AdviceSubtitles;
using Smbs.Application.Features.MediatR.Queries.AdviceTitles;
using Smbs.Application.Features.MediatR.Results.AdviceSubtitles;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.AdviceSubtitles
{
    public class GetByIdAdviceSubtitleQueryHandler(IRepository<AdviceSubtitle> repository) : IRequestHandler<GetAdviceSubtitleByIdQuery, IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>> Handle(GetAdviceSubtitleByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<AdviceSubtitleResult>(DomainError.NotFound("Advice subtitle not found"));
            }
            else
            {
                return Result.Success<AdviceSubtitleResult>(DomainSuccess<AdviceSubtitleResult>.OK(new AdviceSubtitleResult
                {
                    AdviceSubtitleId = result.AdviceSubtitleId,
                    AdviceSubtitleContent = result.AdviceSubtitleContent,
                    AdviceSubtitleAdviceTitleId = result.AdviceSubtitleAdviceTitleId
                }));
            }
        }
    }
}
