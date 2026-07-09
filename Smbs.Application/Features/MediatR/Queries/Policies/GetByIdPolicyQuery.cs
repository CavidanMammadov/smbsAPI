using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Policies;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Policies
{
    public class GetByIdPolicyQuery:IRequest<IResult<DomainSuccess<PolicyResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdPolicyQuery(int id)
        {
            Id = id;
        }
    }
}
