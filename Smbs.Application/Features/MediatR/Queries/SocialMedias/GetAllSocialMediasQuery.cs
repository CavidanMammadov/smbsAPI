using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.SocialMedias;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.SocialMedias
{
    public class GetAllSocialMediasQuery:IRequest<IResult<DomainSuccess<List<SocialMediaResult>>,DomainError>>
    {
    }
}
