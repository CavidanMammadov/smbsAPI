using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.ProgramDownloadings;
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
    public class CreateProgramDownloadingCommandHandler(IRepository<ProgramDownloading> repository) : IRequestHandler<CreateProgramDownloadingCommand, IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>> Handle(CreateProgramDownloadingCommand request, CancellationToken cancellationToken)
        {
            var result = new ProgramDownloading
            {
                ProgramDownloadingBrochureTitle = request.ProgramDownloadingBrochureTitle,
                ProgramDownloadingEmail = request.ProgramDownloadingEmail,
                ProgramDownloadingName = request.ProgramDownloadingName,
                ProgramDownloadingPhoneNumber = request.ProgramDownloadingPhoneNumber,
                ProgramDownloadingSurname = request.ProgramDownloadingSurname
            };
            await repository.Create(result);
            return Result.Success(DomainSuccess<ProgramDownloadingResult>.Created(new ProgramDownloadingResult
            {
                ProgramDownloadingId = result.ProgramDownloadingId,
                ProgramDownloadingBrochureTitle = request.ProgramDownloadingBrochureTitle,
                ProgramDownloadingEmail = request.ProgramDownloadingEmail,
                ProgramDownloadingName = request.ProgramDownloadingName,
                ProgramDownloadingPhoneNumber = request.ProgramDownloadingPhoneNumber,
                ProgramDownloadingSurname = request.ProgramDownloadingSurname
            }));
        }
    }
}
