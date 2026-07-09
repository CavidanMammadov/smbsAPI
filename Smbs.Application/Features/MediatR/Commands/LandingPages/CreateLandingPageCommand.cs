using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.LandingPages
{
    public class CreateLandingPageCommand:IRequest<IResult<DomainSuccess<LandingPageResult>,DomainError>>
    {
        public string LandingPageTitle { get; set; }
        public string LandingPageDescription { get; set; }
        public string LandingPageButton { get; set; }
        public IFormFile LandingPageImage { get; set; }
    }
    public class CreateLandingPageCommandValidator : AbstractValidator<CreateLandingPageCommand>
    {
        public CreateLandingPageCommandValidator()
        {
            RuleFor(x => x.LandingPageTitle)
                .NotEmpty().WithMessage("Landing page title is required.")
                .MaximumLength(100).WithMessage("Landing page title must not exceed 100 characters.");
            RuleFor(x => x.LandingPageDescription).MinimumLength(10).WithMessage("Landing page description must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Landing page description must not exceed 500 characters.");
            RuleFor(x => x.LandingPageButton).NotEmpty().WithMessage("Landing page button text is required.");
        }
    }
}
