using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Applyments;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Applyments
{
    public class GetApplymentsQueryHandler(IRepository<Applyment> repository) : IRequestHandler<GetApplymentsQuery, IResult<DomainSuccess<List<GetApplymentByIdResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<GetApplymentByIdResult>>, DomainError>> Handle(GetApplymentsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<GetApplymentByIdResult>>(DomainError.NotFound("Cant be found"));
            }
            return Result.Success<List<GetApplymentByIdResult>>(DomainSuccess<List<GetApplymentByIdResult>>.OK(result.Select(a => new GetApplymentByIdResult
            {
                ApplymentId = a.ApplymentId,
                ApplymentType = a.ApplymentType,
                ApplymentNameAndSurname = a.ApplymentNameAndSurname,
                ApplymentEmail = a.ApplymentEmail,
                ApplymentPhoneNumber = a.ApplymentPhoneNumber,
                ApplymentTrainingName = a.ApplymentTrainingName
            }).ToList(), "found successfully"));
        }
    }
}
