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
    public class CreateAboutUsCommand : IRequest<IResult<DomainSuccess<CreateAboutUsResult>, DomainError>>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
    public class CreateAboutUsCommandValidator : AbstractValidator<CreateAboutUsCommand>
    {
        public CreateAboutUsCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required.");
            RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("Content is required.");
        }


    }
}
