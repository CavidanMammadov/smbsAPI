using MediatR;
using Microsoft.EntityFrameworkCore;
using Smbs.Application.Features.MediatR.Queries.Blogs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    public class GetBlogsWithPaginationQueryHandler(IBlogRepository repository) : IRequestHandler<GetBlogsWithPaginationQuery, IResult<DomainSuccess<PaginatedResult<ResultBlogDto>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PaginatedResult<ResultBlogDto>>, DomainError>> Handle(GetBlogsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = repository.GetAsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            if (totalCount == 0)
            {
                return Result.Fail<PaginatedResult<ResultBlogDto>>(DomainError.NotFound("No blogs found"));
            }

            var blogs = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(blog => new ResultBlogDto
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
                })
                .ToListAsync(cancellationToken);

            var paginatedData = new PaginatedResult<ResultBlogDto>(blogs, totalCount, request.PageNumber, request.PageSize);

            return Result.Success(DomainSuccess<PaginatedResult<ResultBlogDto>>.OK(paginatedData, "Retrieved successfully"));
        }
    }
}
