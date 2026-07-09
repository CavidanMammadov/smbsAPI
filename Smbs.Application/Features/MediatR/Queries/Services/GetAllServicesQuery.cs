using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Services;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Services
{
    public class GetAllServicesQuery:IRequest<IResult<DomainSuccess<List<ServiceResult>>,DomainError>>
    {
    }
}
