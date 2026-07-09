using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Policies;
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
    public class CreatePolicyCommandHandler(IRepository<Policy> repository) : IRequestHandler<CreatePolicyCommand, IResult<DomainSuccess<PolicyResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PolicyResult>, DomainError>> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            var result = new Policy
            {
                PolicyContent = request.PolicyContent,
            
                PolicyTitle = request.PolicyTitle
            };
            await repository.Create(result);
            return Result.Success(DomainSuccess<PolicyResult>.Created(new PolicyResult
            {
                PolicyId = result.PolicyId,
                PolicyContent = request.PolicyContent,
                
                PolicyTitle = request.PolicyTitle
            }));
        }
    }
}
