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
    public class UpdateProgramDownloadingCommandHandler(IRepository<ProgramDownloading> repository) : IRequestHandler<UpdateProgramDownloadingCommand, IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ProgramDownloadingResult>, DomainError>> Handle(UpdateProgramDownloadingCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.ProgramDownloadingId);
            if (value == null)
            {
                return Result.Fail<ProgramDownloadingResult>(DomainError.NotFound("Not found"));
            }
            else
            {
                value.ProgramDownloadingBrochureTitle = request.ProgramDownloadingBrochureTitle;
                value.ProgramDownloadingSurname = request.ProgramDownloadingSurname;
                value.ProgramDownloadingPhoneNumber = request.ProgramDownloadingPhoneNumber;
                value.ProgramDownloadingName = request.ProgramDownloadingName;
                value.ProgramDownloadingId = request.ProgramDownloadingId;
                await repository.Update(value);
                return Result.Success(DomainSuccess<ProgramDownloadingResult>.OK(new ProgramDownloadingResult
                {
                    ProgramDownloadingId = request.ProgramDownloadingId,
                    ProgramDownloadingEmail = request.ProgramDownloadingEmail,
                    ProgramDownloadingBrochureTitle = request.ProgramDownloadingBrochureTitle,
                    ProgramDownloadingSurname = request.ProgramDownloadingSurname,
                    ProgramDownloadingPhoneNumber = request.ProgramDownloadingPhoneNumber,
                    ProgramDownloadingName = request.ProgramDownloadingName,

                }));
            }
        }
    }
}
