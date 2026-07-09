using MediatR;
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
    public class GetAllBlogModulesQueryHandler(IRepository<BlogModule> repository) : IRequestHandler<GetAllBlogModulesQuery, IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>> Handle(GetAllBlogModulesQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAll();
            if (value == null)
            {
                return Result.Fail<List<BlogModuleResult>>(DomainError.NotFound("No blog modules found"));
            }
            else
            {
                return Result.Success(DomainSuccess<List<BlogModuleResult>>.OK(value.Select(x => new BlogModuleResult
                {
                    BlogModuleId = x.BlogModuleId,
                    BlogModuleBlogId = x.BlogModuleBlogId,
                    BlogModuleContent = x.BlogModuleContent,
                }).ToList(), "Blog modules retrieved successfully"));
            }
        }
    }
}
