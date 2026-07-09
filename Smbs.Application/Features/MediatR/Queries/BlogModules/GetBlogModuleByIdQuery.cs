using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.BlogModules;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.BlogModules
{
    public class GetBlogModuleByIdQuery:IRequest<IResult<DomainSuccess<BlogModuleResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetBlogModuleByIdQuery(int id)
        {
            Id = id;
        }
    }
}
