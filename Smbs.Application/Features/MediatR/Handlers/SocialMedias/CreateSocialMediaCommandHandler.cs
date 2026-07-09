using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Smbs.Application.Features.MediatR.Commands.SocialMedias;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using Smbs.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.SocialMedias
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, IResult<DomainSuccess<SocialMediaResult>, DomainError>>
    {
        private readonly ISocialMediaRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateSocialMediaCommandHandler(ISocialMediaRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<SocialMediaResult>,
            DomainError>> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            if (request.SocialMediaImage == null || request.SocialMediaImage.Length == 0)
                return Result.Fail<SocialMediaResult>(DomainError.BadRequest("Image is required"));

            var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.SocialMediaImage, "SocialMedias");


            if (!string.IsNullOrEmpty(error))
                return Result.Fail<SocialMediaResult>(DomainError.BadRequest($"Cloudinary error: {error}"));
            var media = new SocialMedia
            {
                SocialMediaName = request.SocialMediaName,
                SocialMediaIcon = request.SocialMediaIcon,
                SocialMediaUrl = request.SocialMediaUrl,
                SocialMediaImage=imageUrl
            };
            await _repository.Create(media);
            var dto = new SocialMediaResult
            {
                SocialMediaId =media.SocialMediaId,
                SocialMediaIcon=media.SocialMediaIcon,
                SocialMediaName=media.SocialMediaName,
                SocialMediaUrl=media.SocialMediaUrl,
                SocialMediaImage = imageUrl,
            };
            return Result.Success(DomainSuccess<SocialMediaResult>.Created(dto, "Social media created"));
        }
    }
}
