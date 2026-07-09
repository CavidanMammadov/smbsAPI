using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.BlogModules;
using Smbs.Application.Features.MediatR.Results.BlogModules;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.BlogModules
{
    public class CreateBlogModuleCommandHandler(IRepository<BlogModule> repository) : IRequestHandler<CreateBlogModuleCommand, IResult<DomainSuccess<BlogModuleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<BlogModuleResult>, DomainError>> Handle(CreateBlogModuleCommand request, CancellationToken cancellationToken)
        {
            var blogModule = new BlogModule
            {
                BlogModuleBlogId = request.BlogModuleBlogId,
                BlogModuleContent = request.BlogModuleContent

            };
           await repository.Create(blogModule);
            return Result.Success<BlogModuleResult>(DomainSuccess<BlogModuleResult>.Created(new BlogModuleResult
            {
                BlogModuleId = blogModule.BlogModuleId,
                BlogModuleBlogId = request.BlogModuleBlogId,
                BlogModuleContent = request.BlogModuleContent
            }, "Created successfully"));
        }
    }
}
