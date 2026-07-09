using FluentValidation;
using MediatR;
using Smbs.Application.Features.MediatR.Results.AdviceSubtitles;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.AdviceSubtitles
{
    public class CreateAdviceSubtitleCommand:IRequest<IResult<DomainSuccess<AdviceSubtitleResult>, DomainError>>
    {
        public string AdviceSubtitleContent { get; set; }
        public int AdviceSubtitleAdviceTitleId { get; set; }
    }
    public class CreateAdviceSubtitleCommandValidator : AbstractValidator<CreateAdviceSubtitleCommand>
    {
        public CreateAdviceSubtitleCommandValidator()
        {
            RuleFor(a => a.AdviceSubtitleContent).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(a => a.AdviceSubtitleAdviceTitleId).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
