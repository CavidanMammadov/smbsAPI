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
    public class CreateSocialMediaCommand:IRequest<IResult<DomainSuccess<SocialMediaResult>,DomainError>>
    {
        public string SocialMediaName { get; set; } = string.Empty;
        public string SocialMediaIcon { get; set; } = string.Empty;
        public string SocialMediaUrl { get; set; }
        public IFormFile SocialMediaImage { get; set; }
    }
    public class CreateSocialMediaValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaValidator()
        {
            //RuleFor(x => x.SocialMediaName)
            //    .NotEmpty().WithMessage("Social media name is required.")
            //    .MaximumLength(100).WithMessage("Social media name must not exceed 100 characters.");
            //RuleFor(x => x.SocialMediaIcon)
            //    .NotEmpty().WithMessage("Social media icon is required.")
            //    .MaximumLength(200).WithMessage("Social media icon must not exceed 200 characters.");
            RuleFor(x => x.SocialMediaUrl).NotEmpty().WithMessage("Url annot be empty");
        }
    }
}
