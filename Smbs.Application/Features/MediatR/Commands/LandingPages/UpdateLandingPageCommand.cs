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
    public class UpdateLandingPageCommand:IRequest<IResult<DomainSuccess<LandingPageResult>,DomainError>>
    {
        public int LandingPageId { get; set; }
        public string LandingPageTitle { get; set; }
        public string LandingPageDescription { get; set; }
        public string LandingPageButton { get; set; }
        public IFormFile LandingPageImage { get; set; }
    }
    public class UpdateLandingPageCommandValidator:AbstractValidator<UpdateLandingPageCommand>
    {
        public UpdateLandingPageCommandValidator()
        {
            RuleFor(x => x.LandingPageTitle)
                .NotEmpty().WithMessage("Landing page title is required.")
                .MaximumLength(100).WithMessage("Landing page title must not exceed 100 characters.");
            RuleFor(x => x.LandingPageDescription).NotEmpty().WithMessage("Landing page description is required.")
                .MaximumLength(500).WithMessage("Landing page description must not exceed 500 characters.");
            RuleFor(x => x.LandingPageButton).NotEmpty().WithMessage("Landing page button text is required.")
                .MaximumLength(50).WithMessage("Landing page button text must not exceed 50 characters.");
        }
    }
}
