using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.AdviceSubtitles;
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
    public class GetAllAdviceSubtitlesQueryHandler(IRepository<AdviceSubtitle> repository) : IRequestHandler<GetAdviceSubtitlesQuery, IResult<DomainSuccess<List<AdviceSubtitleResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<AdviceSubtitleResult>>, DomainError>> Handle(GetAdviceSubtitlesQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<AdviceSubtitleResult>>(DomainError.NotFound("No advice subtitles found"));
            }
            else
            {
                var adviceSubtitleResults = result.Select(a => new AdviceSubtitleResult
                {
                    AdviceSubtitleId = a.AdviceSubtitleId,
                    AdviceSubtitleContent = a.AdviceSubtitleContent,
                    AdviceSubtitleAdviceTitleId = a.AdviceSubtitleAdviceTitleId
                }).ToList();
                return Result.Success(DomainSuccess<List<AdviceSubtitleResult>>.OK(adviceSubtitleResults));
            }
        }
    }
}
