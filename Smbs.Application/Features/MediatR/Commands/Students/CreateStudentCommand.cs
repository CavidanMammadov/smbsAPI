using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Trainers;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Students
{
    public class CreateStudentCommand:IRequest<IResult<DomainSuccess<StudentResult>,DomainError>>
    {
        public string StudentNameAndSurname { get; set; }
        public int TrainerId { get; set; }
        public string? StudentScore { get; set; }
        public string StudentCertificateNumber { get; set; }
        public string StudentCertificateType { get; set; }
        public string StudentCertificateTraining { get; set; }
        public string StudentTrainingTime { get; set; }
        public string StudentCertificateGivingTime { get; set; }
        public DateTime StudentCreatedAt { get; set; }  
    }
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {

            RuleFor(x => x.StudentNameAndSurname).NotEmpty().WithMessage("Student name and surname is required");
            RuleFor(x => x.TrainerId).GreaterThan(0).WithMessage("StudentTrainerId must be greather than 0");
            RuleFor(x => x.StudentCertificateNumber).NotEmpty().WithMessage("Student certificate number is required");
            RuleFor(x => x.StudentCertificateType).NotEmpty().WithMessage("Student certificate type is required");
            RuleFor(x => x.StudentCertificateTraining).NotEmpty().WithMessage("Student certificate training is required");
            RuleFor(x => x.StudentTrainingTime).NotEmpty().WithMessage("Student training time is required");
            RuleFor(x => x.StudentCertificateGivingTime).NotEmpty().WithMessage("Student certificate giving time is required");
        }
    }
}
