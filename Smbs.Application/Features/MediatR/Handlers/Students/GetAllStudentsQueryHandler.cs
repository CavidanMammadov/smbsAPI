using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Students;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Students
{
    public class GetAllStudentsQueryHandler(IRepository<Student> repository) : IRequestHandler<GetAllStudentsQuery, IResult<DomainSuccess<List<StudentResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<StudentResult>>, DomainError>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<StudentResult>>(DomainError.NotFound("No students found"));
            }
            return Result.Success(DomainSuccess<List<StudentResult>>.OK(result.Select(x => new StudentResult
            {
                StudentId = x.StudentId,
                StudentNameAndSurname = x.StudentNameAndSurname,
                TrainerId = x.TrainerId,
                StudentScore = x.StudentScore,
                StudentCertificateNumber = x.StudentCertificateNumber,
                StudentCertificateType = x.StudentCertificateType,
                StudentCertificateTraining = x.StudentCertificateTraining,
                StudentTrainingTime = x.StudentTrainingTime,
                StudentCertificateGivingTime = x.StudentCertificateGivingTime,
                StudentCreatedAt = x.StudentCreatedAt,


            }).ToList(), "Students retrieved successfully"));
        }
    }
}
