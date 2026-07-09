using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.LandingPages;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;


namespace Smbs.Application.Features.MediatR.Handlers.LandingPages
{
    public class GetLandingPageByIdQueryHandler(ILandingPageRepository repository) : IRequestHandler<GetLandingPageByIdQuery, IResult<DomainSuccess<LandingPageResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<LandingPageResult>, DomainError>> Handle(GetLandingPageByIdQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<LandingPageResult>(DomainError.NotFound("Landing page not found with given id"));
            }
            return Result.Success<LandingPageResult>(DomainSuccess<LandingPageResult>.OK(new LandingPageResult
            {
                LandingPageId = value.LandingPageId,
                LandingPageButton = value.LandingPageButton,
                LandingPageTitle = value.LandingPageTitle,
                LandingPageDescription = value.LandingPageDescription,
                LandingPageImage = value.LandingPageImage
            },"s"));
        }
    }
}
