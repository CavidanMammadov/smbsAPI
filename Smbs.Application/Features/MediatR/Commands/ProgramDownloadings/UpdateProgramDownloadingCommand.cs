using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.ProgramDownloadings;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.ProgramDownloadings
{
    public class UpdateProgramDownloadingCommand:IRequest<IResult<DomainSuccess<ProgramDownloadingResult>,DomainError>>
    {
        public int ProgramDownloadingId { get; set; }
        public string ProgramDownloadingName { get; set; }
        public string ProgramDownloadingSurname { get; set; }
        public string ProgramDownloadingEmail { get; set; }
        public string ProgramDownloadingBrochureTitle { get; set; }
        public string ProgramDownloadingPhoneNumber { get; set; }
    }
    public class UpdateProgramDownloadingValidator:AbstractValidator<UpdateProgramDownloadingCommand>
    {
        public UpdateProgramDownloadingValidator()
        {
            RuleFor(a => a.ProgramDownloadingName).NotEmpty().WithMessage("Program downloading name is required.");
            RuleFor(a => a.ProgramDownloadingSurname).NotEmpty().WithMessage("Program downloading surname is required.");
            RuleFor(a => a.ProgramDownloadingEmail).NotEmpty().WithMessage("Program downloading email is required.");
            RuleFor(a => a.ProgramDownloadingBrochureTitle).NotEmpty().WithMessage("Program downloading brochure title is required.");
            RuleFor(a => a.ProgramDownloadingPhoneNumber).NotEmpty().WithMessage("Program downloading phone number is required.");
        }
    }
}
