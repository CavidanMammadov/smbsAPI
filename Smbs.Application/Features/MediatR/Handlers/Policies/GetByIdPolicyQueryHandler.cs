using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Policies;
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
    public class GetByIdPolicyQueryHandler(IRepository<Policy> repository) : IRequestHandler<GetByIdPolicyQuery, IResult<DomainSuccess<PolicyResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PolicyResult>, DomainError>> Handle(GetByIdPolicyQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<PolicyResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                return Result.Success(DomainSuccess<PolicyResult>.OK(new PolicyResult
                {
                    PolicyId = value.PolicyId,
                    PolicyContent = value.PolicyContent,
                   
                    PolicyTitle = value.PolicyTitle
                }));
            }
        }
    }
}
