using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.AdviceTitles;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.AdviceTitles
{
    public class CreateAdviceTitleCommand:IRequest<IResult<DomainSuccess<AdviceTitleResult>,DomainError>>
    {
        public string AdviceTitleContent { get; set; }
        public int AdviceTitleAdviceId { get; set; }
    }
    public class CreateAdviceTitleCommandValidator : AbstractValidator<CreateAdviceTitleCommand>
    {
        public CreateAdviceTitleCommandValidator()
        {
            RuleFor(a => a.AdviceTitleContent).NotEmpty().WithMessage("Cannot be empty");
            RuleFor(a => a.AdviceTitleAdviceId).NotEmpty().WithMessage("Cannot be empty");

        }
    }
}
