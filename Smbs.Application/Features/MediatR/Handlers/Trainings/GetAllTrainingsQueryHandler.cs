using MediatR;
using Smbs.Application.Features.MediatR.Queries.Trainings;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    public class GetAllTrainingsQueryHandler(ITrainingRepository repository) : IRequestHandler<GetAllTrainingsQuery, IResult<DomainSuccess<List<TrainingResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<TrainingResult>>, DomainError>> Handle(GetAllTrainingsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<TrainingResult>>(DomainError.NotFound("No training found."));
            }
            else
            {
                return Result.Success(DomainSuccess<List<TrainingResult>>.OK(result.Select(x => new TrainingResult
                {
                    TrainingId = x.TrainingId,
                    TrainingImage = x.TrainingImage,
                    TrainingWorkOpportunity = x.TrainingWorkOpportunity,
                    TrainingFormat = x.TrainingFormat,
                    TrainingPrice = x.TrainingPrice,
                    TrainingSchedule = x.TrainingSchedule,
                    TrainingAbout = x.TrainingAbout,
                    TrainingAddress = x.TrainingAddress,
                    TrainingCoveredTopics = x.TrainingCoveredTopics,
                    TrainingDescription = x.TrainingDescription,
                    TrainingDuration = x.TrainingDuration,
                    TrainingGroupSize = x.TrainingGroupSize,
                    TrainingLanguage = x.TrainingLanguage,
                    TrainingTitle = x.TrainingTitle,
                    TrainingTeacher = x.TrainingTeacher,
                    TrainingTeacherCertificate = x.TrainingTeacherCertificate,
                    TrainingAudienceType = x.TrainingAudienceType,
                }).ToList()));
            }
        }
    }
}
