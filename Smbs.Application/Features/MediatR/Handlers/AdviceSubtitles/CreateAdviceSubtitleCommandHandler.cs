using MediatR;
using Smbs.Application.Features.MediatR.Commands.AdviceSubtitles;
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
    public class CreateAdviceSubtitleCommandHandler(IRepository<AdviceSubtitle> repository) : IRequestHandler<CreateAdviceSubtitleCommand, IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>> Handle(CreateAdviceSubtitleCommand request, CancellationToken cancellationToken)
        {
            var result= new AdviceSubtitle
            {
                AdviceSubtitleContent = request.AdviceSubtitleContent,
                AdviceSubtitleAdviceTitleId = request.AdviceSubtitleAdviceTitleId
            };
            await repository.Create(result);
            return Result.Success<AdviceSubtitleResult>(DomainSuccess<AdviceSubtitleResult>.Created(new AdviceSubtitleResult
            {
                AdviceSubtitleId = result.AdviceSubtitleId,
                AdviceSubtitleContent = result.AdviceSubtitleContent,
                AdviceSubtitleAdviceTitleId = result.AdviceSubtitleAdviceTitleId
            }));
        }
    }
}
