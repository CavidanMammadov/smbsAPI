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
    public class UpdateBlogModuleCommandHandler(IRepository<BlogModule> repository) : IRequestHandler<UpdateBlogModuleCommand, IResult<DomainSuccess<BlogModuleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<BlogModuleResult>, DomainError>> Handle(UpdateBlogModuleCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.BlogModuleId);
            if (result == null)
            {
                return Result.Fail<BlogModuleResult>(DomainError.NotFound("No blog module found with this id"));
            }
            result.BlogModuleBlogId = request.BlogModuleBlogId;
            result.BlogModuleContent = request.BlogModuleContent;
            await repository.Update(result);
            return Result.Success<BlogModuleResult>(DomainSuccess<BlogModuleResult>.OK(new BlogModuleResult
            {
                BlogModuleId = request.BlogModuleId,
                BlogModuleBlogId = request.BlogModuleId,
                BlogModuleContent = request.BlogModuleContent,
            }, "Updated successfully"));
        }
    }
}
