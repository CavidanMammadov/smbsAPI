using MediatR;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Applyments
{
    public class GetApplymentsWithPaginationQuery
        : IRequest<IResult<DomainSuccess<PaginatedResult<ResultApplymentDto>>, DomainError>>
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 10;
    }
}