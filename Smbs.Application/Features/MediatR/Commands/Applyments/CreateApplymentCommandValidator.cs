using FluentValidation;

namespace Smbs.Application.Features.MediatR.Commands.Applyments
{
    public class CreateApplymentCommandValidator : AbstractValidator<CreateApplymentCommand>
    {
        public CreateApplymentCommandValidator()
        {
            RuleFor(x => x.NameAndSurname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name and Surname are required.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Phone number format is invalid.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Email format is invalid.");

            RuleFor(x => x.TrainingName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Training name is required.");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Invalid training type.");
        }
    }
}
