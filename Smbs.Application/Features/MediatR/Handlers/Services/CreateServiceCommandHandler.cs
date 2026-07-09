using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Services;
using Smbs.Application.Features.MediatR.Results.Services;
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
    public class CreateServiceCommandHandler(IRepository<Service> repository) : IRequestHandler<CreateServiceCommand, IResult<DomainSuccess<ServiceResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ServiceResult>, DomainError>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {var service = new Service
        {
            ServiceTitle = request.ServiceTitle,
            ServiceDescription = request.ServiceDescription,
            ServiceIcon = request.ServiceIcon
        };
            await repository.Create(service);
            return Result.Success(DomainSuccess<ServiceResult>.OK(new ServiceResult
            {
                ServiceId = service.ServiceId,
                ServiceTitle = request.ServiceTitle,
                ServiceDescription = request.ServiceDescription,
                ServiceIcon = request.ServiceIcon
            }));
        }
    }
}
