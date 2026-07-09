using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.AboutUs
{
    public class UpdateAboutUsCommand : IRequest<IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>>
    {
        public int AboutUsId { get; set; }
        public string AboutUsTitle { get; set; }
        public string AboutUsContent { get; set; }
        public IFormFile Image { get; set; }
    }
    public class UpdateAboutUsCommandValidator : AbstractValidator<UpdateAboutUsCommand>
    {
        public UpdateAboutUsCommandValidator()
        {
            RuleFor(x => x.AboutUsId).NotEmpty().WithMessage("AboutUsId cant be empty");
            RuleFor(x => x.AboutUsTitle).NotEmpty().WithMessage("AboutUsTitle cant be empty");
            RuleFor(x => x.AboutUsContent).NotEmpty().WithMessage("AboutUsContent cant be empty");
        }
    }
}
