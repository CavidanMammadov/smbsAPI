using MediatR;
using Microsoft.AspNetCore.Hosting;
using Smbs.Application.Features.MediatR.Commands.AboutUs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.AboutUs
{
    #region old version
    //public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, IResult<DomainSuccess<CreateAboutUsResult>, DomainError>>
    //{
    //    private readonly IRepository<Smbs.Domain.Entities.AboutUs> _repository;
    //    private readonly ICloudinaryService _cloudinaryService;
    //    private readonly IWebHostEnvironment _env;

    //    public CreateAboutUsCommandHandler(IRepository<Smbs.Domain.Entities.AboutUs> repository, IWebHostEnvironment env, ICloudinaryService cloudinaryService)
    //    {
    //        _repository = repository;
    //        _env = env;
    //        _cloudinaryService = cloudinaryService;
    //    }

    //    public async Task<IResult<DomainSuccess<CreateAboutUsResult>, DomainError>> Handle(
    //        CreateAboutUsCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 1️⃣ Validation for image
    //        if (request.Image == null || request.Image.Length == 0)
    //            return Result.Fail<CreateAboutUsResult>(DomainError.BadRequest("Image is required"));

    //        // 2️⃣ Save image to wwwroot/uploads/aboutus
    //        var fileName = Guid.NewGuid() + Path.GetExtension(request.Image.FileName);
    //        var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "aboutus");
    //        if (!Directory.Exists(uploadPath))
    //            Directory.CreateDirectory(uploadPath);

    //        var filePath = Path.Combine(uploadPath, fileName);
    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await request.Image.CopyToAsync(stream, cancellationToken);
    //        }

    //        // 3️⃣ Create entity
    //        var aboutUs = new Smbs.Domain.Entities.AboutUs
    //        {
    //            AboutUsTitle = request.Title,
    //            AboutUsContent = request.Content,
    //            AboutUsImage = fileName // DB-də yalnız fayl adı saxlanır
    //        };

    //        await _repository.Create(aboutUs);

    //        // 4️⃣ Response DTO
    //        var dto = new CreateAboutUsResult
    //        {
    //            AboutUsId = aboutUs.AboutUsId,
    //            Title = aboutUs.AboutUsTitle,
    //            Content = aboutUs.AboutUsContent,
    //            Image = aboutUs.AboutUsImage
    //        };

    //        return Result.Success(DomainSuccess<CreateAboutUsResult>.Created(dto, "AboutUs created"));
    //    }
    //}
    #endregion
    public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, IResult<DomainSuccess<CreateAboutUsResult>, DomainError>>
    {
        private readonly IAboutUsRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateAboutUsCommandHandler(IAboutUsRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<CreateAboutUsResult>, DomainError>> Handle(
            CreateAboutUsCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Image == null || request.Image.Length == 0)
                return Result.Fail<CreateAboutUsResult>(DomainError.BadRequest("Image is required"));

            var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.Image, "aboutus");

            if (!string.IsNullOrEmpty(error))
                return Result.Fail<CreateAboutUsResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

            var aboutUs = new Smbs.Domain.Entities.AboutUs
            {
                AboutUsTitle = request.Title,
                AboutUsContent = request.Content,
                AboutUsImage = imageUrl !
            };

            await _repository.Create(aboutUs);

            var dto = new CreateAboutUsResult
            {
                AboutUsId = aboutUs.AboutUsId,
                Title = aboutUs.AboutUsTitle,
                Content = aboutUs.AboutUsContent,
                Image = aboutUs.AboutUsImage
            };

            return Result.Success(DomainSuccess<CreateAboutUsResult>.Created(dto, "AboutUs created"));
        }
    }
}
