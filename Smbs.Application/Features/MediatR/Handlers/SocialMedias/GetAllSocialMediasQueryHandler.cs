using MediatR;
using Smbs.Application.Features.MediatR.Queries.SocialMedias;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.SocialMedias
{
    public class GetAllSocialMediasQueryHandler(IRepository<SocialMedia> repository) : IRequestHandler<GetAllSocialMediasQuery, IResult<DomainSuccess<List<SocialMediaResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<SocialMediaResult>>, DomainError>> Handle(GetAllSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<SocialMediaResult>>(DomainError.NotFound("No social media found."));
            }
            else
            {
                return Result.Success(DomainSuccess<List<SocialMediaResult>>.OK(result.Select(x => new SocialMediaResult
                {
                    SocialMediaId = x.SocialMediaId,
                    SocialMediaName = x.SocialMediaName,
                    SocialMediaIcon = x.SocialMediaIcon,
                    SocialMediaUrl = x.SocialMediaUrl,
                    SocialMediaImage = x.SocialMediaImage,
                }).ToList()));
            }
        }
    }
}
