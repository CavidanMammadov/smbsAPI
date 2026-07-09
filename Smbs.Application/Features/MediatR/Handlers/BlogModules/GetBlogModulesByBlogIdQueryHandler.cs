using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.BlogModules;
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
    public class GetBlogModulesByBlogIdQueryHandler(IRepository<BlogModule> repository) : IRequestHandler<GetBlogModulesByBlogIdQuery, IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>> Handle(GetBlogModulesByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var blogModules=await repository.Where(a=>a.BlogModuleBlogId == request.BlogId);
            if (blogModules == null || !blogModules.Any())
            {
                return Result.Fail<List<BlogModuleResult>>(DomainError.NotFound("No blog modules found for this blog id"));
            }
            return Result.Success(DomainSuccess<List<BlogModuleResult>>.OK(blogModules.Select(x => new BlogModuleResult
            {
                BlogModuleId = x.BlogModuleId,
                BlogModuleContent = x.BlogModuleContent,
                BlogModuleBlogId = x.BlogModuleBlogId
            }).ToList(), "Blog modules retrieved successfully"));
        }
    }
}
