using CloudinaryDotNet;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.AboutUs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.AboutUs
{
    #region Bu əvvəlki halıdı: Hansı ki wwwroot-a düşəndə ordan şəkili də silmək olurdu
    //public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>>
    //{
    //    private readonly IRepository<Smbs.Domain.Entities.AboutUs> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public UpdateAboutUsCommandHandler(IRepository<Smbs.Domain.Entities.AboutUs> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
    //    {
    //        // 1️⃣ Mövcud record-u tap
    //        var aboutUs = await _repository.GetById(request.AboutUsId);
    //        if (aboutUs == null)
    //            return Result.Fail<UpdateAboutUsResult>(DomainError.NotFound("AboutUs not found"));

    //        // 2️⃣ Əgər yeni image varsa, köhnəsini sil və yenisini yaz
    //        if (request.Image != null && request.Image.Length > 0)
    //        {
    //            if (!string.IsNullOrEmpty(aboutUs.AboutUsImage))
    //            {
    //                var oldPath = Path.Combine(_env.WebRootPath, "uploads", "aboutus", aboutUs.AboutUsImage);
    //                if (File.Exists(oldPath))
    //                    File.Delete(oldPath);
    //            }

    //            var fileName = Guid.NewGuid() + Path.GetExtension(request.Image.FileName);
    //            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "aboutus");
    //            if (!Directory.Exists(uploadPath))
    //                Directory.CreateDirectory(uploadPath);

    //            var filePath = Path.Combine(uploadPath, fileName);
    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await request.Image.CopyToAsync(stream, cancellationToken);
    //            }

    //            aboutUs.AboutUsImage = fileName;
    //        }

    //        // 3️⃣ Digər fields update
    //        aboutUs.AboutUsTitle = request.AboutUsTitle;
    //        aboutUs.AboutUsContent = request.AboutUsContent;

    //        // 4️⃣ DB update
    //        await _repository.Update(aboutUs);

    //        // 5️⃣ Response DTO
    //        var dto = new UpdateAboutUsResult
    //        {
    //            AboutUsId = aboutUs.AboutUsId,
    //            Title = aboutUs.AboutUsTitle,
    //            Content = aboutUs.AboutUsContent,
    //            Image = aboutUs.AboutUsImage
    //        };

    //        return Result.Success(DomainSuccess<UpdateAboutUsResult>.OK(dto, "AboutUs updated"));
    //    }
    //}
    #endregion
    public class UpdateAboutUsCommandHandler : IRequestHandler<UpdateAboutUsCommand, IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>>
    {
        private readonly IAboutUsRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;
        public UpdateAboutUsCommandHandler(IAboutUsRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>> Handle(UpdateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var aboutUs = await _repository.GetById(request.AboutUsId);
            if (aboutUs == null)
                return Result.Fail<UpdateAboutUsResult>(DomainError.NotFound("AboutUs not found"));

            if (request.Image != null && request.Image.Length > 0)
            {
                if (!string.IsNullOrEmpty(aboutUs.AboutUsImage))
                {
                    await _cloudinaryService.DeleteImageAsync(aboutUs.AboutUsImage);
                }

                var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.Image, "aboutus");

                if (!string.IsNullOrEmpty(error))
                    return Result.Fail<UpdateAboutUsResult>(DomainError.BadRequest($"Cloudinary error: {error}"));

                aboutUs.AboutUsImage = imageUrl!;
            }

            aboutUs.AboutUsTitle = request.AboutUsTitle;
            aboutUs.AboutUsContent = request.AboutUsContent;

            await _repository.Update(aboutUs);

            var dto = new UpdateAboutUsResult
            {
                AboutUsId = aboutUs.AboutUsId,
                Title = aboutUs.AboutUsTitle,
                Content = aboutUs.AboutUsContent,
                Image = aboutUs.AboutUsImage!
            };

            return Result.Success(DomainSuccess<UpdateAboutUsResult>.OK(dto, "AboutUs updated"));
        }
    }
}
