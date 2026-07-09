using MediatR;
using Smbs.Application.Features.MediatR.Queries.SocialMedias;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.SocialMedias
{
    public class GetByIdSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        : IRequestHandler<GetByIdSocialMediaQuery,
            IResult<DomainSuccess<SocialMediaResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<SocialMediaResult>, DomainError>> Handle(
            GetByIdSocialMediaQuery request,
            CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);

            if (result == null)
            {
                return Result.Fail<SocialMediaResult>(
                    DomainError.NotFound("Social media not found."));
            }

            return Result.Success(
                DomainSuccess<SocialMediaResult>.OK(
                    new SocialMediaResult
                    {
                        SocialMediaId = result.SocialMediaId,
                        SocialMediaName = result.SocialMediaName,
                        SocialMediaIcon = result.SocialMediaIcon,
                        SocialMediaUrl = result.SocialMediaUrl,
                        SocialMediaImage = result.SocialMediaImage
                    }));
        }
    }
}