using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Students;
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
    public class DeleteStudentCommandHandler(IRepository<Student> repository) : IRequestHandler<DeleteStudentCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var user = await repository.GetById(request.Id);
            if (user == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Cant be found in this id"));
            }
            await repository.Delete(user);
            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
