using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.LandingPages;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.LandingPages
{
    #region Old version
    //public class UpdateLandingPageCommandHandler : IRequestHandler<UpdateLandingPageCommand, IResult<DomainSuccess<LandingPageResult>, DomainError>>
    //{
    //    private readonly IRepository<LandingPage> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public UpdateLandingPageCommandHandler(IRepository<LandingPage> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<LandingPageResult>, DomainError>> Handle(
    //        UpdateLandingPageCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 1️⃣ Mövcud landing page-i tap
    //        var landingPage = await _repository.GetById(request.LandingPageId);
    //        if (landingPage == null)
    //            return Result.Fail<LandingPageResult>(DomainError.NotFound("Landing page not found"));

    //        // 2️⃣ Əgər yeni image varsa, köhnəsini sil və yenisini yaz
    //        if (request.LandingPageImage != null && request.LandingPageImage.Length > 0)
    //        {
    //            // Köhnə faylı sil
    //            if (!string.IsNullOrEmpty(landingPage.LandingPageImage))
    //            {
    //                var oldPath = Path.Combine(_env.WebRootPath, "uploads", "landingpage", landingPage.LandingPageImage);
    //                if (File.Exists(oldPath))
    //                    File.Delete(oldPath);
    //            }

    //            // Yeni faylı yaz
    //            var fileName = Guid.NewGuid() + Path.GetExtension(request.LandingPageImage.FileName);
    //            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "landingpage");
    //            if (!Directory.Exists(uploadPath))
    //                Directory.CreateDirectory(uploadPath);

    //            var filePath = Path.Combine(uploadPath, fileName);
    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await request.LandingPageImage.CopyToAsync(stream, cancellationToken);
    //            }

    //            landingPage.LandingPageImage = fileName;
    //        }

    //        // 3️⃣ Digər field-ları update et
    //        landingPage.LandingPageTitle = request.LandingPageTitle;
    //        landingPage.LandingPageDescription = request.LandingPageDescription;
    //        landingPage.LandingPageButton = request.LandingPageButton;

    //        // 4️⃣ DB update
    //        await _repository.Update(landingPage);

    //        // 5️⃣ Response DTO
    //        var dto = new LandingPageResult
    //        {
    //            LandingPageId = landingPage.LandingPageId,
    //            LandingPageTitle = landingPage.LandingPageTitle,
    //            LandingPageDescription = landingPage.LandingPageDescription,
    //            LandingPageButton = landingPage.LandingPageButton,
    //            LandingPageImage = landingPage.LandingPageImage
    //        };

    //        return Result.Success(DomainSuccess<LandingPageResult>.OK(dto, "Landing page updated"));
    //    }
    //}
    #endregion
    public class UpdateLandingPageCommandHandler : IRequestHandler<UpdateLandingPageCommand, IResult<DomainSuccess<LandingPageResult>, DomainError>>
    {
        private readonly ILandingPageRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public UpdateLandingPageCommandHandler(ILandingPageRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<LandingPageResult>, DomainError>> Handle(
            UpdateLandingPageCommand request,
            CancellationToken cancellationToken)
        {
            var landingPage = await _repository.GetById(request.LandingPageId);
            if (landingPage == null)
                return Result.Fail<LandingPageResult>(DomainError.NotFound("Landing page not found"));

            if (request.LandingPageImage != null && request.LandingPageImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(landingPage.LandingPageImage))
                {
                    await _cloudinaryService.DeleteImageAsync(landingPage.LandingPageImage);
                }

                var(imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.LandingPageImage, "landingpage");

                if (!string.IsNullOrEmpty(error))
                    return Result.Fail<LandingPageResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

                landingPage.LandingPageImage = imageUrl!;
            }

            landingPage.LandingPageTitle = request.LandingPageTitle;
            landingPage.LandingPageDescription = request.LandingPageDescription;
            landingPage.LandingPageButton = request.LandingPageButton;

            await _repository.Update(landingPage);

            var dto = new LandingPageResult
            {
                LandingPageId = landingPage.LandingPageId,
                LandingPageTitle = landingPage.LandingPageTitle,
                LandingPageDescription = landingPage.LandingPageDescription,
                LandingPageButton = landingPage.LandingPageButton,
                LandingPageImage = landingPage.LandingPageImage
            };

            return Result.Success(DomainSuccess<LandingPageResult>.OK(dto, "Landing page updated"));
        }
    }
}
