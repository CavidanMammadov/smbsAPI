using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Policies;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Policies
{
    public class CreatePolicyCommand:IRequest<IResult<DomainSuccess<PolicyResult>,DomainError>>
    {
        public string PolicyTitle { get; set; }
        public string PolicyContent { get; set; }
       
    }
    public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommand>
    {
        public CreatePolicyCommandValidator()
        {
            RuleFor(a=>a.PolicyContent).NotEmpty().WithMessage("Policy content is required.");
            RuleFor(a => a.PolicyTitle).NotEmpty().WithMessage("Policy title is required.");
           
        }
    }
}
