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
    public class GetAllProgramDownloadingQueryHandler(IRepository<ProgramDownloading> repository) : IRequestHandler<GetAllProgramDownloadingQuery, IResult<DomainSuccess<List<ProgramDownloadingResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<ProgramDownloadingResult>>, DomainError>> Handle(GetAllProgramDownloadingQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<ProgramDownloadingResult>>(DomainError.NotFound("Not found"));
            }
            return Result.Success<List<ProgramDownloadingResult>>(DomainSuccess<List<ProgramDownloadingResult>>.OK(result.Select(a => new ProgramDownloadingResult
            {
                ProgramDownloadingId = a.ProgramDownloadingId,
                ProgramDownloadingBrochureTitle = a.ProgramDownloadingBrochureTitle,
                ProgramDownloadingEmail = a.ProgramDownloadingEmail,
                ProgramDownloadingName = a.ProgramDownloadingName,
                ProgramDownloadingPhoneNumber = a.ProgramDownloadingPhoneNumber,
                ProgramDownloadingSurname = a.ProgramDownloadingSurname
            }).ToList()));
        }
    }
}
