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
    public class UpdatePolicyCommandHandler(IRepository<Policy> repository) : IRequestHandler<UpdatePolicyCommand, IResult<DomainSuccess<PolicyResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PolicyResult>, DomainError>> Handle(UpdatePolicyCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.PolicyId);
            if (value == null)
            {
                return Result.Fail<PolicyResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                value.PolicyContent = request.PolicyContent;
                
                value.PolicyTitle = request.PolicyTitle;
                
                await repository.Update(value);
                return Result.Success(DomainSuccess<PolicyResult>.OK(new PolicyResult
                {PolicyId = request.PolicyId,
                    PolicyContent = request.PolicyContent,
                 
                    PolicyTitle = request.PolicyTitle
                }));
            }
        }
    }
}