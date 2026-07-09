using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Domain;
using Smbs.Domain.Results;


namespace Smbs.Application.Features.MediatR.Commands.Trainers
{
    public class CreateTrainerCommand : IRequest<IResult<DomainSuccess<TrainerResult>, DomainError>>
    {
        public string TrainerNameAndSurname { get; set; } = null!;
        public string TrainerPosition { get; set; } = null!;
        public string TrainerDescription { get; set; } = null!;
        public IFormFile? TrainerVideo {  get; set; } = null!;
        public IFormFile TrainerImgUrl { get; set; } = null!;

    }
    public class CreateTrainerCommandValidator : AbstractValidator<CreateTrainerCommand>
    {
        public CreateTrainerCommandValidator()
        {

            RuleFor(x => x.TrainerNameAndSurname)
                .NotEmpty().WithMessage("Trainer name and surname is required.")
                .MaximumLength(100).WithMessage("Trainer name and surname must not exceed 100 characters.");
            RuleFor(x => x.TrainerPosition)
                .NotEmpty().WithMessage("TrainerPosition is required")
                .MaximumLength(128)
                .WithMessage("TrainerPosition must be less than 128 character");

            RuleFor(x => x.TrainerDescription)
                .NotEmpty().WithMessage("Trainer description is required.");
            //.MaximumLength(500).WithMessage("Trainer description must not exceed 500 characters.");

            

            RuleFor(x => x.TrainerImgUrl)
                .NotNull().WithMessage("Trainer image file is required.");
        }
    }
}
