using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.SocialMedias
{
    public class UpdateSocialMediaCommand:IRequest<IResult<DomainSuccess<SocialMediaResult>,DomainError>>
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaUrl { get; set; }
        public IFormFile SocialMediaImage { get; set; }
    }
    public class UpdateSocialMediaValidator : AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaValidator()
        {
            RuleFor(x => x.SocialMediaId)
                .NotEmpty().WithMessage("Social media ID is required.")
                .GreaterThan(0).WithMessage("Social media ID must be greater than 0.");
            //RuleFor(x => x.SocialMediaName)
            //    .NotEmpty().WithMessage("Social media name is required.")
            //    .MaximumLength(100).WithMessage("Social media name must not exceed 100 characters.");
            //RuleFor(x => x.SocialMediaIcon)
            //    .NotEmpty().WithMessage("Social media icon is required.")
            //    .MaximumLength(200).WithMessage("Social media icon must not exceed 200 characters.");
            RuleFor(x => x.SocialMediaUrl).NotEmpty().WithMessage("Cannot be empty");
        }
    }
}
