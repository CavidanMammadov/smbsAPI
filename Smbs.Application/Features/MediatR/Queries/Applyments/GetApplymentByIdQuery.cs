using MediatR;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Queries.Applyments
{
    public class GetApplymentByIdQuery : IRequest<IResult<DomainSuccess<GetApplymentByIdResult>, DomainError>>
    {
        public int Id { get; set; }

        public GetApplymentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
    