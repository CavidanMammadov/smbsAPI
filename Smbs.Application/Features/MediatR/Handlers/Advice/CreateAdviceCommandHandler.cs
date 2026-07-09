using CloudinaryDotNet;
using MediatR;
using Smbs.Application.Features.MediatR.Commands.Advice;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Advice
{
    public class CreateAdviceCommandHandler : IRequestHandler<CreateAdviceCommand, IResult<DomainSuccess<CreateAdviceResult>, DomainError>>
    {
        private readonly IRepository<Smbs.Domain.Entities.Advice> _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateAdviceCommandHandler(IRepository<Smbs.Domain.Entities.Advice> repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<CreateAdviceResult>, DomainError>> Handle(CreateAdviceCommand request, CancellationToken cancellationToken)
        {
            if (request.AdviceImage == null || request.AdviceImage.Length == 0)
                return Result.Fail<CreateAdviceResult>(DomainError.BadRequest("AdviceImage required"));

            var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.AdviceImage, "Advices");
            if (!string.IsNullOrEmpty(error))
                return Result.Fail<CreateAdviceResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

            var advice = new Smbs.Domain.Entities.Advice
            {
                AdviceTitle = request.AdviceTitle,
                AdviceDescription = request.AdviceDescription,
                AdviceImage = imageUrl,
                AdviceContent = request.AdviceContent,
                AdviceDuration = request.AdviceDuration
            };

            await _repository.Create(advice);

            var result = new CreateAdviceResult
            {
                AdviceId = advice.AdviceId,
                AdviceTitle = advice.AdviceTitle,
                AdviceImage = imageUrl,
                AdviceDescription = advice.AdviceDescription,
                AdviceContent = advice.AdviceContent,
                AdviceDuration = advice.AdviceDuration
            };

            return Result.Success<CreateAdviceResult>(DomainSuccess<CreateAdviceResult>.Created(result,"Created"));
        }
    }
}
