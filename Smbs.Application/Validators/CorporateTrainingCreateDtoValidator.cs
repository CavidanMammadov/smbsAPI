using FluentValidation;
using Smbs.Application.DTOs.CorporateTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Validators
{
    public class CorporateTrainingCreateDtoValidator :AbstractValidator<CorporateTrainingCreateDto>
    {
        public CorporateTrainingCreateDtoValidator()
        {
            RuleFor(x => x.CorporateTrainingCompanyName)
               .NotEmpty()
               .WithMessage("Şirkət adı boş ola bilməz.");

            RuleFor(x => x.CorporateTrainingPosition)
                .NotEmpty()
                .WithMessage("Vəzifə boş ola bilməz.");

            RuleFor(x => x.CorporateTrainingDirection)
                .NotEmpty()
                .WithMessage("Təlim istiqaməti boş ola bilməz.");

            RuleFor(x => x.CorporateTrainingSchedule)
                .NotEmpty()
                .WithMessage("Təlim qrafiki boş ola bilməz.");

            RuleFor(x => x.CorporateTrainingContactInfo)
                .NotEmpty()
                .WithMessage("Əlaqə məlumatı boş ola bilməz.");

            RuleFor(x => x.CorporateTrainingEmployeeCount)
                .GreaterThan(0)
                .WithMessage("Əməkdaş sayı 0-dan böyük olmalıdır.");

            RuleFor(x => x.CorporateTrainingContractDate)
                .NotEmpty()
                .WithMessage("Müqavilə tarixi boş ola bilməz.");
        }
    }
}
