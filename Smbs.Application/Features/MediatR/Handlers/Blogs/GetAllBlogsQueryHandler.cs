using MediatR;
using Smbs.Application.Features.MediatR.Queries.Blogs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    public class GetAllBlogsQueryHandler(IBlogRepository repository) : IRequestHandler<GetAllBlogsQuery, IResult<DomainSuccess<List<ResultBlogDto>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<ResultBlogDto>>, DomainError>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllWithModulesAsync();
            if (result == null)
            {
                return Result.Fail<List<ResultBlogDto>>(DomainError.NotFound("No blogs found"));
            }
            return Result.Success(DomainSuccess<List<ResultBlogDto>>.OK(result.Select(blog => new ResultBlogDto
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

                Result = blog.BlogResult
            }).ToList(), "Retrieved successfully"));
        }
    }
}
