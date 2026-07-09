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
    public class GetByIdBlogModuleCommandHandler(IRepository<BlogModule> repository) : IRequestHandler<GetBlogModuleByIdQuery, IResult<DomainSuccess<BlogModuleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<BlogModuleResult>, DomainError>> Handle(GetBlogModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<BlogModuleResult>(DomainError.NotFound("No blog module found with this id"));
            }
            return Result.Success(DomainSuccess<BlogModuleResult>.OK(new BlogModuleResult
            {
                BlogModuleId = value.BlogModuleId,
                BlogModuleBlogId = value.BlogModuleBlogId,
                BlogModuleContent = value.BlogModuleContent,
            }, "Blog module retrieved successfully"));
        }
    }
}
