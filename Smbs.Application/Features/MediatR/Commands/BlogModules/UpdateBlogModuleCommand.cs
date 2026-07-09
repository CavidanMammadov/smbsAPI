using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.BlogModules;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.BlogModules
{
    public class UpdateBlogModuleCommand:IRequest<IResult<DomainSuccess<BlogModuleResult>,DomainError>>
    {
        public int BlogModuleId { get; set; }
        public string BlogModuleContent { get; set; }
        public int BlogModuleBlogId { get; set; }
    }
    public class UpdateBlogModuleCommandValidator : AbstractValidator<UpdateBlogModuleCommand>
    {
        public UpdateBlogModuleCommandValidator()
        {
            RuleFor(x => x.BlogModuleId).NotEmpty().WithMessage("Blog module id is required.");
            RuleFor(x => x.BlogModuleContent).NotEmpty().WithMessage("Blog module content is required.");
            RuleFor(x => x.BlogModuleBlogId).NotEmpty().WithMessage("Blog module blog id is required.");
        }
    }
}
