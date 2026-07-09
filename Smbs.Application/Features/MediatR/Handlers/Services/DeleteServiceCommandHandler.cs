using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Services;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Services
{
    public class DeleteServiceCommandHandler(IRepository<Service> repository) : IRequestHandler<DeleteServiceCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Not found"));
            }
            else
            {
                await repository.Delete(value);
                return Result.Success(DomainSuccess<int>.OK(request.Id));
            }
        }
    }
}
