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
    public class GetAllServiceQueryHandler(IRepository<Service> repository) : IRequestHandler<GetAllServicesQuery, IResult<DomainSuccess<List<ServiceResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<ServiceResult>>, DomainError>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<ServiceResult>>(DomainError.NotFound("Not found"));
            }
            else
            {
                return Result.Success(DomainSuccess<List<ServiceResult>>.OK(result.Select(x => new ServiceResult
                {
                    ServiceId = x.ServiceId,
                    ServiceTitle = x.ServiceTitle,
                    ServiceDescription = x.ServiceDescription,
                    ServiceIcon = x.ServiceIcon
                }).ToList()));
            }
        }
    }
}