using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.AboutUs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;


namespace Smbs.Application.Features.MediatR.Handlers.AboutUs
{
    public class GetByIdAboutUsQueryHandler(IAboutUsRepository repository) : IRequestHandler<GetByIdAboutUsQuery, IResult<DomainSuccess<GetByIdAboutUsResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<GetByIdAboutUsResult>, DomainError>> Handle(GetByIdAboutUsQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<GetByIdAboutUsResult>(DomainError.NotFound($"AboutUs with ID {request.Id} was not found."));
            }
            return Result.Success<GetByIdAboutUsResult>(DomainSuccess<GetByIdAboutUsResult>.Accepted(new GetByIdAboutUsResult {AboutUsId=value.AboutUsId, Content=value.AboutUsContent,Title=value.AboutUsTitle, Image = value.AboutUsImage},"Accepted successfully"));
        }
    }
}
