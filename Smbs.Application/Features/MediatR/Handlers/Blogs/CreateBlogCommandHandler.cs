using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Blogs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    #region Old version 
    //public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    //{
    //    private readonly IRepository<Blog> _repository;
    //    private readonly IWebHostEnvironment _env;

    //    public CreateBlogCommandHandler(IRepository<Blog> repository, IWebHostEnvironment env)
    //    {
    //        _repository = repository;
    //        _env = env;
    //    }

    //    public async Task<IResult<DomainSuccess<ResultBlogDto>, DomainError>> Handle(
    //        CreateBlogCommand request,
    //        CancellationToken cancellationToken)
    //    {
    //        // 🔴 1. Validation (basic)
    //        if (request.BlogImage == null || request.BlogImage.Length == 0)
    //            return Result.Fail<ResultBlogDto>(DomainError.BadRequest("BlogImage required"));

    //        // 🔴 2. Fayl adı yarat
    //        var fileName = Guid.NewGuid() + Path.GetExtension(request.BlogImage.FileName);

    //        // 🔴 3. Path qur
    //        var uploadPath = Path.Combine(_env.WebRootPath, "uploads", "blogs");

    //        if (!Directory.Exists(uploadPath))
    //            Directory.CreateDirectory(uploadPath);

    //        var filePath = Path.Combine(uploadPath, fileName);

    //        // 🔴 4. File save et
    //        using (var stream = new FileStream(filePath, FileMode.Create))
    //        {
    //            await request.BlogImage.CopyToAsync(stream, cancellationToken);
    //        }

    //        // 🔴 5. DB entity yarat
    //        var blog = new Blog
    //        {
    //            BlogTitle = request.BlogTitle,
    //            BlogDescription = request.BlogDescription,
    //            BlogImage = fileName,
    //            BlogResult = request.Result
    //            // DB-də yalnız ad saxlanılır
    //        };

    //        await _repository.Create(blog);

    //        // 🔴 6. Response DTO
    //        var dto = new ResultBlogDto
    //        {
    //            BlogId = blog.BlogId,
    //            BlogTitle = blog.BlogTitle,
    //            BlogDescription = blog.BlogDescription,
    //            BlogImage = fileName,
    //            Result = blog.BlogResult
    //        };

    //        return Result.Success(DomainSuccess<ResultBlogDto>.Created(dto, "Blog created"));
    //    }
    //}
    #endregion
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IResult<DomainSuccess<ResultBlogDto>, DomainError>>
    {
        private readonly IBlogRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateBlogCommandHandler(IBlogRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<ResultBlogDto>, DomainError>> Handle(
            CreateBlogCommand request,
            CancellationToken cancellationToken)
        {
            if (request.BlogImage == null || request.BlogImage.Length == 0)
                return Result.Fail<ResultBlogDto>(DomainError.BadRequest("BlogImage required"));

            var (imageUrl, publicId, error) = await _cloudinaryService.UploadImageAsync(request.BlogImage, "blogs");

            if (!string.IsNullOrEmpty(error))
                return Result.Fail<ResultBlogDto>(DomainError.BadRequest($"Cloudinary error: {error}"));

            var blog = new Blog
            {
                BlogTitle = request.BlogTitle,
                BlogDescription = request.BlogDescription,
                BlogImage = imageUrl,
                BlogResult=request.Result                
            };

            await _repository.Create(blog);

            var dto = new ResultBlogDto
            {
                BlogId = blog.BlogId,
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                 BlogImage= imageUrl,
                 Result = blog.BlogResult
            };

            return Result.Success(DomainSuccess<ResultBlogDto>.Created(dto, "Blog created"));
        }
    }
}
