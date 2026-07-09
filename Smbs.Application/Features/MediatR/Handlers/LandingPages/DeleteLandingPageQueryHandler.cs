using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.LandingPages;
using Smbs.Application.Services.Abstract;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.LandingPages
{
    #region old version
    //public class DeleteLandingPageQueryHandler(IRepository<LandingPage> repository) : IRequestHandler<DeleteLandingPageCommand, IResult<DomainSuccess<int>, DomainError>>
    //{
    //    public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteLandingPageCommand request, CancellationToken cancellationToken)
    //    {
    //        var value = await repository.GetById(request.Id);
    //        if (value == null)
    //        {
    //            return Result.Fail<int>(DomainError.NotFound("Landing page not found"));
    //        }
    //        await repository.Delete(value);
    //        return Result.Success(DomainSuccess<int>.OK(value.LandingPageId, "deleted"));
    //    }
    //}
    #endregion
    public class DeleteLandingPageQueryHandler: IRequestHandler<DeleteLandingPageCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        private readonly ILandingPageRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;

        public DeleteLandingPageQueryHandler(ILandingPageRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteLandingPageCommand request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetById(request.Id);

            if (value == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Landing page not found"));
            }

            if(!string.IsNullOrEmpty(value.LandingPageImage))
            {
                var deleteResult = await _cloudinaryService.DeleteImageAsync(value.LandingPageImage);

                if (!deleteResult)
                {
                    Console.WriteLine($"Failed to delete image: {value.LandingPageImage}");
                }
            }

            await _repository.Delete(value);

            return Result.Success(DomainSuccess<int>.OK(value.LandingPageId, "deleted"));
        }
    }
}
