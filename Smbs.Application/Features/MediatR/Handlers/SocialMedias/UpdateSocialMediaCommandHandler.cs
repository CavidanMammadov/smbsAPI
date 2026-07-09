using MediatR;
using Smbs.Application.Features.MediatR.Commands.SocialMedias;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.SocialMedias
{
    public class UpdateSocialMediaCommandHandler
        : IRequestHandler<UpdateSocialMediaCommand,
            IResult<DomainSuccess<SocialMediaResult>, DomainError>>
    {
        private readonly ISocialMediaRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public UpdateSocialMediaCommandHandler(
            ISocialMediaRepository repository,
            ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<SocialMediaResult>, DomainError>> Handle(
            UpdateSocialMediaCommand request,
            CancellationToken cancellationToken)
        {
            var socialMedia = await _repository.GetById(request.SocialMediaId);

            if (socialMedia == null)
                return Result.Fail<SocialMediaResult>(
                    DomainError.NotFound("Social media not found"));

            socialMedia.SocialMediaName = request.SocialMediaName;
            socialMedia.SocialMediaIcon = request.SocialMediaIcon;
            socialMedia.SocialMediaUrl = request.SocialMediaUrl;

            if (request.SocialMediaImage != null &&
                request.SocialMediaImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(socialMedia.SocialMediaImage))
                {
                    await _cloudinaryService.DeleteImageAsync(
                        socialMedia.SocialMediaImage);
                }

                var (imageUrl, publicId, error) =
                    await _cloudinaryService.UploadImageAsync(
                        request.SocialMediaImage,
                        "SocialMedias");

                if (!string.IsNullOrEmpty(error))
                {
                    return Result.Fail<SocialMediaResult>(
                        DomainError.BadRequest(
                            $"Cloudinary error: {error}"));
                }

                socialMedia.SocialMediaImage = imageUrl;
            }

            await _repository.Update(socialMedia);

            var dto = new SocialMediaResult
            {
                SocialMediaId = socialMedia.SocialMediaId,
                SocialMediaName = socialMedia.SocialMediaName,
                SocialMediaIcon = socialMedia.SocialMediaIcon,
                SocialMediaUrl = socialMedia.SocialMediaUrl,
                SocialMediaImage = socialMedia.SocialMediaImage
            };

            return Result.Success(
                DomainSuccess<SocialMediaResult>.OK(
                    dto,
                    "Social media updated"));
        }
    }
}