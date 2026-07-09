using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.AboutUs;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.AboutUs
{
    #region Old version
    //public class DeleteAboutUsCommandHandler(IRepository<Smbs.Domain.Entities.AboutUs> repository) : IRequestHandler<DeleteAboutUsCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
    //    {
    //        var value = await repository.GetById(request.Id);
    //        if (value == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound($"AboutUs with id {request.Id} not found."));
    //        }
    //        await repository.Delete(value);
    //        return Result.Success<int>(DomainSuccess<int>.OK(request.Id, "deleted successfully"));
    //    }
    //}
    #endregion
    public class DeleteAboutUsCommandHandler : IRequestHandler<DeleteAboutUsCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly IAboutUsRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public DeleteAboutUsCommandHandler(IAboutUsRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<int>(DomainError.NotFound($"AboutUs with id {request.Id} not found."));
            }

            if (!string.IsNullOrEmpty(value.AboutUsImage))
            {
                var deleteResult = await _cloudinaryService.DeleteImageAsync(value.AboutUsImage);

                if (!deleteResult)
                {
                    Console.WriteLine($"Failed to delete image: {value.AboutUsImage}");
                }
            }

            await _repository.Delete(value);

            return Result.Success<int>(DomainSuccess<int>.OK(request.Id, "deleted successfully"));
        }
    }
}


  
