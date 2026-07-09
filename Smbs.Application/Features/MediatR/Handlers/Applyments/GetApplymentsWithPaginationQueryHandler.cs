using MediatR;
using Microsoft.EntityFrameworkCore;
using Smbs.Application.Features.MediatR.Queries.Applyments;
using Smbs.Application.Features.MediatR.Queries.Blogs;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Enums;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Applyments
{
    public class GetApplymentsWithPaginationQueryHandler(IApplymentRepository repository)
         : IRequestHandler<GetApplymentsWithPaginationQuery,
             IResult<DomainSuccess<PaginatedResult<ResultApplymentDto>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<PaginatedResult<ResultApplymentDto>>, DomainError>> Handle(
            GetApplymentsWithPaginationQuery request,
            CancellationToken cancellationToken)
        {
            var query = repository.GetAsQueryable();

            var totalCount = await query.CountAsync(cancellationToken);

            if (totalCount == 0)
            {
                return Result.Fail<PaginatedResult<ResultApplymentDto>>
                (
                    DomainError.NotFound("No applyments found")
                );
            }

            var applyments = await query
                .AsNoTracking()
                .OrderBy(x => x.ApplymentId)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ResultApplymentDto
                {
                    ApplymentId = x.ApplymentId,
                    ApplymentNameAndSurname =x.ApplymentNameAndSurname,
                    ApplymentPhoneNumber =x.ApplymentPhoneNumber,
                    ApplymentType=x.ApplymentType,
                    ApplymentEmail=x.ApplymentEmail,
                    ApplymentTrainingName   =x.ApplymentTrainingName,

    })
                .ToListAsync(cancellationToken);

            var paginatedData = new PaginatedResult<ResultApplymentDto>
            (
                applyments,
                totalCount,
                request.PageNumber,
                request.PageSize
            );

            return Result.Success
            (
                DomainSuccess<PaginatedResult<ResultApplymentDto>>
                .OK(paginatedData, "Retrieved successfully")
            );
        }
    }
}
