using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.LandingPages;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Application.Features.MediatR.Results.LandingPages;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.LandingPages
{
    #region old version
    //public class CreateLandingPageCommandHandler : IRequestHandler<CreateLandingPageCommand, IResult<DomainSuccess<LandingPageResult>, DomainError>>
    //{
    //    private readonly IRepository<LandingPage> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public CreateLandingPageCommandHandler(IRepository<LandingPage> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<LandingPageResult>, DomainError>> Handle(
    //        CreateLandingPageCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 🔹 1. Image validation
    //        if (request.LandingPageImage == null || request.LandingPageImage.Length == 0)
    //            return Result.Fail<LandingPageResult>(DomainError.BadRequest("Landing page image is required"));

    //        // 🔹 2. Save image to wwwroot/uploads
    //        var fileName = Guid.NewGuid() + Path.GetExtension(request.LandingPageImage.FileName);
    //        var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "landingpage");

    //        if (!Directory.Exists(uploadPath))
    //            Directory.CreateDirectory(uploadPath);

    //        var filePath = Path.Combine(uploadPath, fileName);
    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await request.LandingPageImage.CopyToAsync(stream, cancellationToken);
    //        }

    //        // 🔹 3. Create LandingPage entity
    //        var landingPage = new LandingPage
    //        {
    //            LandingPageTitle = request.LandingPageTitle,
    //            LandingPageDescription = request.LandingPageDescription,
    //            LandingPageButton = request.LandingPageButton,
    //            LandingPageImage = fileName // DB-də yalnız fayl adı saxlanılır
    //        };

    //        await _repository.Create(landingPage);

    //        // 🔹 4. Response DTO
    //        var dto = new LandingPageResult
    //        {
    //            LandingPageId = landingPage.LandingPageId,
    //            LandingPageTitle = landingPage.LandingPageTitle,
    //            LandingPageDescription = landingPage.LandingPageDescription,
    //            LandingPageButton = landingPage.LandingPageButton,
    //            LandingPageImage = landingPage.LandingPageImage
    //        };

    //        return Result.Success(DomainSuccess<LandingPageResult>.Created(dto, "Landing page created"));
    //    }
    //}
    #endregion
    public class CreateLandingPageCommandHandler : IRequestHandler<CreateLandingPageCommand, IResult<DomainSuccess<LandingPageResult>, DomainError>>
    {
        private readonly ILandingPageRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateLandingPageCommandHandler(ILandingPageRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<LandingPageResult>, DomainError>> Handle(
            CreateLandingPageCommand request,
            CancellationToken cancellationToken)
        {
            if (request.LandingPageImage == null || request.LandingPageImage.Length == 0)
                return Result.Fail<LandingPageResult>(DomainError.BadRequest("Landing page image is required"));

            var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.LandingPageImage, "landingpage");

            if (!string.IsNullOrEmpty(error))
                return Result.Fail<LandingPageResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

            var landingPage = new LandingPage
            {
                LandingPageTitle = request.LandingPageTitle,
                LandingPageDescription = request.LandingPageDescription,
                LandingPageButton = request.LandingPageButton,
                LandingPageImage = imageUrl !
            };

            await _repository.Create(landingPage);

            var dto = new LandingPageResult
            {LandingPageId = landingPage.LandingPageId,
                LandingPageTitle = landingPage.LandingPageTitle,
                LandingPageDescription = landingPage.LandingPageDescription,
                LandingPageButton = landingPage.LandingPageButton,
                LandingPageImage = landingPage.LandingPageImage
            };

            return Result.Success(DomainSuccess<LandingPageResult>.Created(dto, "Landing page created"));
        }
    }
}
