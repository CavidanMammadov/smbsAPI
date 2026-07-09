using MediatR;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Students
{
    public class GetStudentsWithPaginationQuery : IRequest<IResult<DomainSuccess<PaginatedResult<StudentResult>>, DomainError>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetStudentsWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
