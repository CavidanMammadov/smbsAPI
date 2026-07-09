using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Blogs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    public class GetByIdBlogQueryHandler(IBlogRepository repository) : IRequestHandler<GetByIdBlogQuery, IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultBlogDto>, DomainError>> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
        {
            var blog=await repository.GetByIdWithModulesAsync(request.Id);
            if (blog == null)
            {
                return Result.Fail<ResultBlogDto>(DomainError.NotFound("Blog not found"));
            }
            return Result.Success(DomainSuccess<ResultBlogDto>.OK(new ResultBlogDto
            {
                BlogId = blog.BlogId,
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                BlogImage = blog.BlogImage,
                BlogModules = blog.BlogModules.Select(x => new BlogModule
                {
                    BlogModuleBlogId = x.BlogModuleBlogId,
                    BlogModuleId = x.BlogModuleId,
                    BlogModuleContent = x.BlogModuleContent
                }).ToList(),
                Result =blog.BlogResult
            }, "Retrieved successfully"));
        }
    }
}
