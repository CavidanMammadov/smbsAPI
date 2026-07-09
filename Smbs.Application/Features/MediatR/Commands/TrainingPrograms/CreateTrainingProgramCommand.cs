using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.TrainingPrograms;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.TrainingPrograms
{
    public class CreateTrainingProgramCommand : IRequest<IResult<DomainSuccess<TrainingProgramResult>, DomainError>>
    {
        public string TrainingProgramTitle { get; set; }
        public string TrainingProgramDescription { get; set; }
        public int TrainingProgramTrainerId { get; set; }
    }
    public class CreateTrainingProgramValidator : AbstractValidator<CreateTrainingProgramCommand>
    {
        public CreateTrainingProgramValidator()
        {
            RuleFor(x => x.TrainingProgramTitle).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.TrainingProgramDescription).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.TrainingProgramTrainerId).GreaterThan(0).WithMessage("TrainerId must be greater than 0");
        }
    }
}
