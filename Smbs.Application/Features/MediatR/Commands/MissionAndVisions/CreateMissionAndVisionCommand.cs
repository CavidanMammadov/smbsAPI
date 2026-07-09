using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.MissionAndVisions;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.MissionAndVisions
{
    public class CreateMissionAndVisionCommand:IRequest<IResult<DomainSuccess<MissionAndVisionResult>,DomainError>>
    {
        public string MissionAndVisionTitle { get; set; }
        public string MissionAndVisionContent { get; set; }
        
    }
    public class CreateMissionAndVisionCommandValidator : AbstractValidator<CreateMissionAndVisionCommand>
    {
        public CreateMissionAndVisionCommandValidator()
        {
            RuleFor(a=>a.MissionAndVisionTitle).NotEmpty().WithMessage("MissionAndVisionTitle cannot be empty");
          
            RuleFor(a => a.MissionAndVisionContent).NotEmpty().WithMessage("MissionAndVisionContent cannot be empty");
        }
    }
}
