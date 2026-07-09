using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smbs.Application.Features.MediatR.Queries.Students;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Students
{
    public class GetStudentsWithPaginationQueryHandler(IStudentRepository repository) : IRequestHandler<GetStudentsWithPaginationQuery, IResult<DomainSuccess<PaginatedResult<StudentResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PaginatedResult<StudentResult>>, DomainError>> Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = repository.GetAsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            if (totalCount == 0)
            {
                return Result.Fail<PaginatedResult<StudentResult>>(DomainError.NotFound("No students found"));
            }

            var students = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new StudentResult
                {
                    StudentId = x.StudentId,
                    StudentNameAndSurname = x.StudentNameAndSurname,
                    TrainerId = x.TrainerId,
                    StudentScore = x.StudentScore,
                    StudentCertificateNumber = x.StudentCertificateNumber,
                    StudentCertificateType = x.StudentCertificateType,
                    StudentCertificateTraining = x.StudentCertificateTraining,
                    StudentTrainingTime = x.StudentTrainingTime,
                    StudentCertificateGivingTime = x.StudentCertificateGivingTime
                })
                .ToListAsync(cancellationToken);

            var paginatedData = new PaginatedResult<StudentResult>(students, totalCount, request.PageNumber, request.PageSize);

            return Result.Success(DomainSuccess<PaginatedResult<StudentResult>>.OK(paginatedData, "Students retrieved successfully with pagination"));
        }
    }
}
