using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Enums;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Trainings
{
    public class UpdateTrainingCommand:IRequest<IResult<DomainSuccess<TrainingResult>,DomainError>>
    {
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; }
        public IFormFile TrainingImage { get; set; }
        public string TrainingDescription { get; set; }
        public string TrainingDuration { get; set; }
        public string TrainingGroupSize { get; set; }
        public string TrainingLanguage { get; set; }
        public string TrainingAbout { get; set; }
        public string TrainingCoveredTopics { get; set; }
        public string TrainingSchedule { get; set; }
        public string TrainingAddress { get; set; }
        public string TrainingWorkOpportunity { get; set; }
        public string TrainingFormat { get; set; }
        public int TrainingPrice { get; set; }
        public string TrainingTeacher { get; set; }
        public int TrainingAudienceType { get; set; }
        public string? TrainingTeacherCertificate { get; set; }
    }
    public class UpdateTrainingCommandValidator : AbstractValidator<UpdateTrainingCommand>
    {
        public UpdateTrainingCommandValidator()
        {
            RuleFor(x => x.TrainingTitle)
                .NotEmpty().WithMessage("Training title is required.")
                .MaximumLength(200).WithMessage("Training title must not exceed 200 characters.");
            RuleFor(x => x.TrainingDescription)
                 .NotEmpty().WithMessage("Training description is required.")
                 .MaximumLength(1000).WithMessage("Training description must not exceed 1000 characters.");
            RuleFor(x => x.TrainingDuration)
                .NotEmpty().WithMessage("Training duration is required.")
                .MaximumLength(50).WithMessage("Training duration must not exceed 50 characters.");
            RuleFor(x => x.TrainingGroupSize)
                .NotEmpty().WithMessage("Training group size is required.")
                .MaximumLength(50).WithMessage("Training group size must not exceed 50 characters.");
            RuleFor(x => x.TrainingLanguage)
                .NotEmpty().WithMessage("Training language is required.")
                .MaximumLength(50).WithMessage("Training language must not exceed 50 characters.");
            RuleFor(x => x.TrainingAbout)
                .NotEmpty().WithMessage("Training about is required.")
                .MaximumLength(1000).WithMessage("Training about must not exceed 1000 characters.");
            RuleFor(x => x.TrainingCoveredTopics)
                .NotEmpty().WithMessage("Training covered topics is required.")
                .MaximumLength(1000).WithMessage("Training covered topics must not exceed 1000 characters.");
            RuleFor(x => x.TrainingSchedule)
                .NotEmpty().WithMessage("Training schedule is required.")
                .MaximumLength(500).WithMessage("Training schedule must not exceed 500 characters.");
            RuleFor(x => x.TrainingAddress)
                .NotEmpty().WithMessage("Training address is required.")
                .MaximumLength(500).WithMessage("Training address must not exceed 500 characters.");
            RuleFor(x => x.TrainingWorkOpportunity)
                .NotEmpty().WithMessage("Training work opportunity is required.")
                .MaximumLength(1000).WithMessage("Training work opportunity must not exceed 1000 characters.");
            RuleFor(x => x.TrainingFormat).MaximumLength(50).WithMessage("Training format must not exceed 50 characters.");
            RuleFor(x => x.TrainingPrice)
               .GreaterThanOrEqualTo(0).WithMessage("Training price must be greater than or equal to 0.");
            RuleFor(x => x.TrainingTeacher).NotEmpty().WithMessage("TrainingTeacher cannot be empty");
          


        }
    }
}
