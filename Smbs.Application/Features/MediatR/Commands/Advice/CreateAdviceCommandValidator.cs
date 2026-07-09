using FluentValidation;

namespace Smbs.Application.Features.MediatR.Commands.Advice
{
    public class CreateAdviceCommandValidator : AbstractValidator<CreateAdviceCommand>
    {
        public CreateAdviceCommandValidator()
        {
            RuleFor(x => x.AdviceTitle)
                .NotEmpty()
                .NotNull()
                .WithMessage("Advice title is required.");

            RuleFor(x => x.AdviceDescription)
                .NotEmpty()
                .NotNull()
                .WithMessage("Advice description is required.");

            RuleFor(x => x.AdviceContent)
                .NotEmpty()
                .NotNull()
                .WithMessage("Advice content is required.");


            RuleFor(x => x.AdviceDuration)
                .NotEmpty()
                .NotNull()
                .WithMessage("Advice duration is required.");
        }
    }
}
