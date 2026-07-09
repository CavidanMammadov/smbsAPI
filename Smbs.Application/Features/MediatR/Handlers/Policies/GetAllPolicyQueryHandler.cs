using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Policies;
using Smbs.Application.Features.MediatR.Results.Policies;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Policies
{
    public class GetAllPolicyQueryHandler(IRepository<Policy> repository) : IRequestHandler<GetAllPoliciesQuery, IResult<DomainSuccess<List<PolicyResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<PolicyResult>>, DomainError>> Handle(GetAllPoliciesQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetAll();
            if (value == null)
            {
                return Result.Fail<List<PolicyResult>>(DomainError.NotFound("Not found"));
            }
            return Result.Success<List<PolicyResult>>(DomainSuccess<List<PolicyResult>>.OK(value.Select(a => new PolicyResult
            {
                PolicyId = a.PolicyId,
                PolicyContent = a.PolicyContent,
                
                PolicyTitle = a.PolicyTitle
            }).ToList()));
        }
    }
}
