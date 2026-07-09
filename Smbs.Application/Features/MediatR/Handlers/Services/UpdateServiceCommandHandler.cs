using MediatR;
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
    public class UpdateServiceCommandHandler(IRepository<Service> repository) : IRequestHandler<UpdateServiceCommand, IResult<DomainSuccess<ServiceResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ServiceResult>, DomainError>> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var value=await repository.GetById(request.ServiceId);
            if (value == null) {

                return Result.Fail<ServiceResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                value.ServiceTitle = request.ServiceTitle;
                value.ServiceDescription = request.ServiceDescription;
                value.ServiceIcon = request.ServiceIcon;
                await repository.Update(value);
                return Result.Success(DomainSuccess<ServiceResult>.OK(new ServiceResult
                {ServiceId = value.ServiceId,
                    ServiceTitle = request.ServiceTitle,
                    ServiceDescription = request.ServiceDescription,
                    ServiceIcon = request.ServiceIcon
                }));
            }
        }
    }
}
