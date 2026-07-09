using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Blogs
{
    public class UpdateBlogCommand : IRequest<IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public IFormFile BlogImage { get; set; }
        public string Result { get; set; }
    }
    public class UpdateBlogCommandvalidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandvalidator()
        {
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog id is required.");
            RuleFor(x => x.BlogTitle)
                .NotEmpty().WithMessage("Blog title is required.")
                .MaximumLength(100).WithMessage("Blog title must not exceed 100 characters.");
            RuleFor(x => x.BlogDescription).NotEmpty().WithMessage("Blog description is required.")
                .MaximumLength(500).WithMessage("Blog description must not exceed 500 characters.");
            RuleFor(x => x.Result).NotEmpty().WithMessage("Blog result is required.");
        }
    }
}
