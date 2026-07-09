using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Smbs.Application.Features.MediatR.Commands.Students;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using Smbs.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Students
{
    public class CreateStudentCommandHandler(IRepository<Student> repository, IRepository<Trainer> trainerRepo) : IRequestHandler<CreateStudentCommand, IResult<DomainSuccess<StudentResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<StudentResult>, DomainError>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var trainer = await trainerRepo
    .GetById(request.TrainerId);

            if (trainer is null)
            {
                throw new DirectoryNotFoundException("bu id-li trainer tapilmadi");
            }
                var user = new Student
            {
                StudentNameAndSurname = request.StudentNameAndSurname,
                TrainerId = request.TrainerId,
                StudentScore = request.StudentScore,
                StudentCertificateNumber = request.StudentCertificateNumber,
                StudentCertificateType = request.StudentCertificateType,
                StudentCertificateTraining = request.StudentCertificateTraining,
                StudentTrainingTime = request.StudentTrainingTime,
                StudentCertificateGivingTime = request.StudentCertificateGivingTime,
                StudentCreatedAt = request.StudentCreatedAt

            };
            
           await repository.Create(user);
            return Result.Success<StudentResult>(DomainSuccess<StudentResult>.Created(new StudentResult
            {
                StudentId = user.StudentId,
                StudentNameAndSurname = user.StudentNameAndSurname,
                TrainerId =user.TrainerId,
                StudentScore = user.StudentScore,
                StudentCertificateNumber = user.StudentCertificateNumber,
                StudentCertificateType = user.StudentCertificateType,
                StudentCertificateTraining = user.StudentCertificateTraining,
                StudentTrainingTime = user.StudentTrainingTime,
                StudentCertificateGivingTime = user.StudentCertificateGivingTime,
                StudentCreatedAt = user.StudentCreatedAt


            }, "Created successfully"));
        }
    }
}
