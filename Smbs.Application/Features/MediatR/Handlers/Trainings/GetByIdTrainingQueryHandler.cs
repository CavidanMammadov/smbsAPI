using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Trainings;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    public class GetByIdTrainingQueryHandler(ITrainingRepository repository) : IRequestHandler<GetByIdTrainingQuery, IResult<DomainSuccess<TrainingResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<TrainingResult>, DomainError>> Handle(GetByIdTrainingQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<TrainingResult>(DomainError.NotFound("Cant be found"));
            }
            return Result.Success<TrainingResult>(DomainSuccess<TrainingResult>.OK(new TrainingResult
            {
                TrainingId = result.TrainingId,
                TrainingImage = result.TrainingImage,
                TrainingAbout = result.TrainingAbout,
                TrainingAddress = result.TrainingAddress,
                TrainingCoveredTopics = result.TrainingCoveredTopics,
                TrainingDescription = result.TrainingDescription,
                TrainingDuration = result.TrainingDuration,
                TrainingGroupSize = result.TrainingGroupSize,
                TrainingTitle = result.TrainingTitle,
                TrainingLanguage = result.TrainingLanguage,
                TrainingSchedule = result.TrainingSchedule,
                TrainingPrice = result.TrainingPrice,
                TrainingFormat = result.TrainingFormat,
                TrainingWorkOpportunity = result.TrainingWorkOpportunity,
                TrainingTeacher = result.TrainingTeacher,
                TrainingTeacherCertificate = result.TrainingTeacherCertificate,
                TrainingAudienceType = result.TrainingAudienceType

            },"Found successfully"));
        }
    }
}
