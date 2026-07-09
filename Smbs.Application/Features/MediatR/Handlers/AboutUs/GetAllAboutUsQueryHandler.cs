using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.AboutUs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.AboutUs
{
    public class GetAllAboutUsQueryHandler(IAboutUsRepository repository) : IRequestHandler<GetAllAboutUsQuery, IResult<DomainSuccess<List<GetAboutUsResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<GetAboutUsResult>>, DomainError>> Handle(GetAllAboutUsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAll();
            return Result.Success(DomainSuccess<List<GetAboutUsResult>>.OK(values.Select(x => new GetAboutUsResult
            {
                AboutUsId = x.AboutUsId,
                Title = x.AboutUsTitle,
                Content = x.AboutUsContent,
                Image = x.AboutUsImage
            }).ToList()));
        }
    }
}
