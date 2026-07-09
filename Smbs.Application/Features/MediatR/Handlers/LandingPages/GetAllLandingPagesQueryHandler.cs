using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.LandingPages;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.LandingPages
{
    public class GetAllLandingPagesQueryHandler(ILandingPageRepository repository) : IRequestHandler<GetAllLandingPagesQuery, IResult<DomainSuccess<List<LandingPageResult>>, DomainError>>
    {
        private readonly ILandingPageRepository _repository;

        public async Task<IResult<DomainSuccess<List<LandingPageResult>>, DomainError>> Handle(GetAllLandingPagesQuery request, CancellationToken cancellationToken)
        {
            var values =await repository.GetAll();
            if (values == null)
            {
                return Result.Fail<List<LandingPageResult>>(DomainError.NotFound("Result not found"));
            }
            return Result.Success(DomainSuccess<List<LandingPageResult>>.OK(values.Select(a => new LandingPageResult
            {
                LandingPageId = a.LandingPageId,
                LandingPageButton = a.LandingPageButton,
                LandingPageDescription = a.LandingPageDescription,
                LandingPageTitle = a.LandingPageTitle,
                LandingPageImage = a.LandingPageImage
            }).ToList(), "found successfully"));
        }
    }
}
