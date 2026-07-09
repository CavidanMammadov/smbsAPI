using MediatR;
using Smbs.Application.Features.MediatR.Commands.Advice;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Reflection.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Advice
{
    public class UpdateAdviceCommandHandler : IRequestHandler<UpdateAdviceCommand, IResult<DomainSuccess<CreateAdviceResult>, DomainError>>
    {
        private readonly IRepository<Smbs.Domain.Entities.Advice> _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public UpdateAdviceCommandHandler(IRepository<Smbs.Domain.Entities.Advice> repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<CreateAdviceResult>, DomainError>> Handle(UpdateAdviceCommand request, CancellationToken cancellationToken)
        {

            var advice = await _repository.GetById(request.AdviceId);
            if (advice == null)
            {
                return Result.Fail<CreateAdviceResult>(
                    DomainError.NotFound("Advice not found."));
            }

            advice.AdviceTitle = request.AdviceTitle;
            advice.AdviceDescription = request.AdviceDescription;
            advice.AdviceContent = request.AdviceContent;
            advice.AdviceDuration = request.AdviceDuration;

            if (advice.AdviceImage != null || advice.AdviceImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(advice.AdviceImage))
                {
                    await _cloudinaryService.DeleteImageAsync(advice.AdviceImage);
                }
                var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.AdviceImage, "Advices");

                if (!string.IsNullOrEmpty(error))
                    return Result.Fail<CreateAdviceResult>(DomainError.BadRequest($"Cloudinary error: {error}"));
                advice.AdviceImage = imageUrl;
            }

            await _repository.Update(advice);

            return Result.Success(DomainSuccess<CreateAdviceResult>.OK(new CreateAdviceResult
            {
              AdviceId = request.AdviceId,
                AdviceTitle = advice.AdviceTitle,
                AdviceImage = advice.AdviceImage,
                AdviceDescription = advice.AdviceDescription,
                AdviceContent = advice.AdviceContent,
                AdviceDuration = advice.AdviceDuration
            }, "Advice updated successfully."));
        }
    }
}
