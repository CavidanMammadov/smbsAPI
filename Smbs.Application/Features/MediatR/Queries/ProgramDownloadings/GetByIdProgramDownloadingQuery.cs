using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.ProgramDownloadings;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.ProgramDownloadings
{
    public class GetByIdProgramDownloadingQuery:IRequest<IResult<DomainSuccess<ProgramDownloadingResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdProgramDownloadingQuery(int id)
        {
            Id = id;
        }
    }
}
