using CloudinaryDotNet;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Blogs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    #region old version: photo wwwroot
    //public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    //{
    //    private readonly IRepository<Blog> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public UpdateBlogCommandHandler(IRepository<Blog> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<ResultBlogDto>, DomainError>> Handle(
    //        UpdateBlogCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 🔹 1. Blog mövcuddurmu yoxla
    //        var blog = await _repository.GetById(request.BlogId);
    //        if (blog == null)
    //            return Result.Fail<ResultBlogDto>(DomainError.NotFound("Blog not found"));

    //        // 🔹 2. Blog məlumatını update et
    //        blog.BlogTitle = request.BlogTitle;
    //        blog.BlogDescription = request.BlogDescription;

    //        blog.BlogResult = request.Result;

    //        // 🔹 3. Əgər yeni şəkil gəlirsə, faylı save et
    //        if (request.BlogImage != null && request.BlogImage.Length > 0)
    //        {
    //            // 3a. Köhnə faylı silmək (optional)
    //            if (!string.IsNullOrEmpty(blog.BlogImage))
    //            {
    //                var oldPath = Path.Combine(_env.WebRootPath, "uploads", "blogs", blog.BlogImage);
    //                if (File.Exists(oldPath))
    //                    File.Delete(oldPath);
    //            }

    //            // 3b. Yeni faylı saxlamaq
    //            var fileName = Guid.NewGuid() + Path.GetExtension(request.BlogImage.FileName);
    //            var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "blogs");
    //            if (!Directory.Exists(uploadPath))
    //                Directory.CreateDirectory(uploadPath);

    //            var filePath = Path.Combine(uploadPath, fileName);
    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                await request.BlogImage.CopyToAsync(stream, cancellationToken);
    //            }

    //            blog.BlogImage = fileName; // DB-də yalnız fayl adı saxlanılır
    //        }

    //        // 🔹 4. DB update
    //        await _repository.Update(blog);

    //        // 🔹 5. Response DTO
    //        var dto = new ResultBlogDto
    //        {
    //            BlogId = blog.BlogId,
    //            BlogTitle = blog.BlogTitle,
    //            BlogDescription = blog.BlogDescription,
    //            BlogImage = blog.BlogImage,
    //            BlogModules = blog.BlogModules,
    //            Result = blog.BlogResult
    //        };

    //        return Result.Success(DomainSuccess<ResultBlogDto>.OK(dto, "Blog updated"));
    //    }
    //}
    #endregion
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    {
        private readonly IBlogRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;
        public UpdateBlogCommandHandler(IBlogRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<ResultBlogDto>, DomainError>> Handle(
            UpdateBlogCommand request,
            CancellationToken cancellationToken)
        {
            var blog = await _repository.GetById(request.BlogId);
            if (blog == null)
                return Result.Fail<ResultBlogDto>(DomainError.NotFound("Blog not found"));

            blog.BlogTitle = request.BlogTitle;
            blog.BlogDescription = request.BlogDescription;
            blog.BlogResult = request.Result;

            if (request.BlogImage != null && request.BlogImage.Length > 0)
            {
                if (!string.IsNullOrEmpty(blog.BlogImage)) 
                {
                    await _cloudinaryService.DeleteImageAsync(blog.BlogImage);
                }

                var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.BlogImage, "blogs");

                if (!string.IsNullOrEmpty(error))
                    return Result.Fail<ResultBlogDto>(DomainError.BadRequest($"Cloudinary error: {error}"));

                blog.BlogImage = imageUrl;
            }

            await _repository.Update(blog);

            var dto = new ResultBlogDto
            {
                BlogId = blog.BlogId,
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                BlogImage = blog.BlogImage,
                BlogModules = blog.BlogModules,
                Result = blog.BlogResult
            };

            return Result.Success(DomainSuccess<ResultBlogDto>.OK(dto, "Blog updated"));
        }
    }
}
