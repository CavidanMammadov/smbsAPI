using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Services;
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
    public class GetByIdServiceCommandHandler(IRepository<Service> repository) : IRequestHandler<GetByIdServiceQuery, IResult<DomainSuccess<ServiceResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ServiceResult>, DomainError>> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            if (value==null)
            {
                return Result.Fail<ServiceResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                return Result.Success(DomainSuccess<ServiceResult>.OK(new ServiceResult
                {
                    ServiceId = value.ServiceId,
                    ServiceTitle = value.ServiceTitle,
                    ServiceDescription = value.ServiceDescription,
                    ServiceIcon = value.ServiceIcon
                }));

            }
        }
    }
}
