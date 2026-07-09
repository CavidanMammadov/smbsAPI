using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.HeroSections;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.HeroSections
{
    public class UpdateHeroSectionCommand:IRequest<IResult<DomainSuccess<ResultHeroSectionDto>,DomainError>>
    {
        public int HeroSectionId { get; set; }
        public string HeroSectionTitle { get; set; }
        public string HeroSectionDescription { get; set; }
    }
    public class UpdateHeroSectionCommandValidator : AbstractValidator<UpdateHeroSectionCommand>
    {
        public UpdateHeroSectionCommandValidator()
        {
            RuleFor(x => x.HeroSectionTitle)
                .NotEmpty().WithMessage("Hero section title is required.")
                .MaximumLength(100).WithMessage("Hero section title must not exceed 100 characters.");
            RuleFor(x => x.HeroSectionDescription).Length(0, 500).WithMessage("Hero section description must not exceed 500 characters.");
        }
    }
}
