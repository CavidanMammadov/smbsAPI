using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.AdviceSubtitles;
using Smbs.Application.Features.MediatR.Commands.AdviceTitles;
using Smbs.Application.Features.MediatR.Results.AdviceSubtitles;
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

namespace Smbs.Application.Features.MediatR.Handlers.AdviceSubtitles
{
    public class UpdateAdviceSubtitleCommandHandler(IRepository<AdviceSubtitle> repository) : IRequestHandler<UpdateAdviceSubtitleCommand, IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>> Handle(UpdateAdviceSubtitleCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.AdviceSubtitleId);
            if (result == null)
            {
                return Result.Fail<AdviceSubtitleResult>(DomainError.NotFound("Advice title not found"));
            }
            else
            {
                result.AdviceSubtitleContent = request.AdviceSubtitleContent;
                result.AdviceSubtitleAdviceTitleId = request.AdviceSubtitleAdviceTitleId;
                await repository.Update(result);
                return Result.Success<AdviceSubtitleResult>(DomainSuccess<AdviceSubtitleResult>.OK(new AdviceSubtitleResult
                {
                    AdviceSubtitleId = result.AdviceSubtitleId,
                    AdviceSubtitleAdviceTitleId = result.AdviceSubtitleAdviceTitleId,
                    AdviceSubtitleContent = result.AdviceSubtitleContent
                  
                }));
            }
        }
    }
}
