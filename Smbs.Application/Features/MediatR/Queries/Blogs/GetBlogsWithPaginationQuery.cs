using MediatR;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Blogs;

public class GetBlogsWithPaginationQuery : IRequest<IResult<DomainSuccess<PaginatedResult<ResultBlogDto>>, DomainError>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public GetBlogsWithPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}