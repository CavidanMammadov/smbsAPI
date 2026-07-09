using FluentValidation;
using MediatR;
using Smbs.Application.Features.MediatR.Results.Contacts;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Contacts
{
    public class CreateContactCommand:IRequest<IResult<DomainSuccess<ResultContactDto>, DomainError>>
    {
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string ContactLocation { get; set; }
    }
    public class CreateContactCommandValidator:AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(x => x.ContactPhoneNumber)
                .NotEmpty().WithMessage("Contact phone number is required.")
                .MaximumLength(20).WithMessage("Contact phone number must not exceed 20 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact email is required.")
                .EmailAddress().WithMessage("Contact email must be a valid email address.")
                .MaximumLength(100).WithMessage("Contact email must not exceed 100 characters.");
            RuleFor(x => x.ContactLocation)
                .NotEmpty().WithMessage("Contact location is required.")
                .MaximumLength(200).WithMessage("Contact location must not exceed 200 characters.");
        }
    }
}
