using MediatR;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Trainings;

public class GetTrainingsWithPaginationQuery : IRequest<IResult<DomainSuccess<PaginatedResult<TrainingResult>>, DomainError>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public GetTrainingsWithPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
