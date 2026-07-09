using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Students;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Students
{
    public class GetByIdStudentQueryHandler(IRepository<Student> repository) : IRequestHandler<GetByIdStudentQuery, IResult<DomainSuccess<StudentResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<StudentResult>, DomainError>> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<StudentResult>(DomainError.NotFound("No student found with this id"));
            }
            return Result.Success(DomainSuccess<StudentResult>.OK(new StudentResult
            {
                StudentId = result.StudentId,
                StudentNameAndSurname = result.StudentNameAndSurname,
                TrainerId = result.TrainerId,
                StudentScore = result.StudentScore,
                StudentCertificateNumber = result.StudentCertificateNumber,
                StudentCertificateType = result.StudentCertificateType,
                StudentCertificateTraining = result.StudentCertificateTraining,
                StudentTrainingTime = result.StudentTrainingTime,
                StudentCertificateGivingTime = result.StudentCertificateGivingTime
            }, "Student retrieved successfully"));
        }
    }
}
