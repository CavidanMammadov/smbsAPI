using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.AdviceSubtitles;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.AdviceSubtitles
{
    public class GetAdviceSubtitleByIdQuery:IRequest<IResult<DomainSuccess<AdviceSubtitleResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetAdviceSubtitleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
