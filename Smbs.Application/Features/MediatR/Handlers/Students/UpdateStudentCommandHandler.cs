using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Smbs.Application.Features.MediatR.Commands.Students;
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
    public class UpdateStudentCommandHandler(IRepository<Student> repository, IRepository<Trainer> trainerRepo) : IRequestHandler<UpdateStudentCommand, IResult<DomainSuccess<StudentResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<StudentResult>, DomainError>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var user =await repository.GetById(request.StudentId);
            if (user == null)
            {
                return Result.Fail<StudentResult>(DomainError.NotFound("Cant be found in this id"));
            }
            var trainer =await trainerRepo.GetById(request.TrainerId);
            if (user == null)
            {
                return Result.Fail<StudentResult>(DomainError.NotFound("Cant be  found trainer in this id"));
            }
            user.StudentNameAndSurname = request.StudentNameAndSurname;
            user.StudentCertificateNumber = request.StudentCertificateNumber;
            user.StudentCertificateType = request.StudentCertificateType;
            user.TrainerId = request.TrainerId;
            user.StudentScore = request.StudentScore;

            user.StudentCertificateTraining = request.StudentCertificateTraining;
            user.StudentCertificateGivingTime = request.StudentCertificateGivingTime;
            user.StudentTrainingTime = request.StudentTrainingTime;

            await repository.Update(user);
            return Result.Success(DomainSuccess<StudentResult>.OK(new StudentResult
            {
                StudentId = user.StudentId,
                StudentNameAndSurname = user.StudentNameAndSurname,
                TrainerId = request.TrainerId,
                StudentScore = request.StudentScore,
                StudentCertificateGivingTime = user.StudentCertificateGivingTime,
                StudentCertificateNumber = user.StudentCertificateNumber,
                StudentTrainingTime = user.StudentTrainingTime,
                StudentCertificateTraining = user.StudentCertificateTraining,
                StudentCertificateType = user.StudentCertificateType
            }));

        }
    }
}
