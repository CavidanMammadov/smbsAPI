using MediatR;
using Microsoft.EntityFrameworkCore;
using Smbs.Application.Features.MediatR.Queries.Trainings;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Trainings
{
    public class GetTrainingsWithPaginationQueryHandler(ITrainingRepository repository) : IRequestHandler<GetTrainingsWithPaginationQuery, IResult<DomainSuccess<PaginatedResult<TrainingResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PaginatedResult<TrainingResult>>, DomainError>> Handle(GetTrainingsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = repository.GetAsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            if (totalCount == 0)
            {
                return Result.Fail<PaginatedResult<TrainingResult>>(DomainError.NotFound("No training found."));
            }

            var trainings = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new TrainingResult
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
                    TrainingAudienceType = x.TrainingAudienceType
                })
                .ToListAsync(cancellationToken);

            var paginatedData = new PaginatedResult<TrainingResult>(trainings, totalCount, request.PageNumber, request.PageSize);

            return Result.Success(DomainSuccess<PaginatedResult<TrainingResult>>.OK(paginatedData, "Trainings retrieved successfully with pagination"));
        }
    }
}
