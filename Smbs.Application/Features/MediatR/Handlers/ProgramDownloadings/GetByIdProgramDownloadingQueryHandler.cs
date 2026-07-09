using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.ProgramDownloadings;
using Smbs.Application.Features.MediatR.Results.ProgramDownloadings;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.ProgramDownloadings
{
    public class GetByIdProgramDownloadingQueryHandler(IRepository<ProgramDownloading> repository) : IRequestHandler<GetByIdProgramDownloadingQuery, IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>> Handle(GetByIdProgramDownloadingQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<ProgramDownloadingResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                return Result.Success(DomainSuccess<ProgramDownloadingResult>.OK(new ProgramDownloadingResult
                {
                    ProgramDownloadingId = value.ProgramDownloadingId,
                    ProgramDownloadingBrochureTitle = value.ProgramDownloadingBrochureTitle,
                    ProgramDownloadingEmail = value.ProgramDownloadingEmail,
                    ProgramDownloadingName = value.ProgramDownloadingName,
                    ProgramDownloadingPhoneNumber = value.ProgramDownloadingPhoneNumber,
                    ProgramDownloadingSurname = value.ProgramDownloadingSurname,
                }));
            }
        }
    }
}
