using CloudinaryDotNet;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Blogs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Blogs
{
    #region Old version
    //public class DeleteBlogCommandHandler(IRepository<Blog> repository) : IRequestHandler<DeleteBlogCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    //    {
    //        var blog = await repository.GetById(request.Id);
    //        if (blog == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound("Blog not found"));
    //        }
    //        await repository.Delete(blog);
    //        return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
    //    }
    //}
    #endregion
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IBlogRepository _repository;

        public DeleteBlogCommandHandler(ICloudinaryService cloudinaryService, IBlogRepository repository)
        {
            _cloudinaryService = cloudinaryService;
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetById(request.Id);

            if (blog == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Blog not found"));
            }

            if (!string.IsNullOrEmpty(blog.BlogImage))
            {
                var deleteResult = await _cloudinaryService.DeleteImageAsync(blog.BlogImage);

                if (!deleteResult)
                {
                    Console.WriteLine($"Failed to delete image: {blog.BlogImage}");
                }
            }

            await _repository.Delete(blog);

            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
