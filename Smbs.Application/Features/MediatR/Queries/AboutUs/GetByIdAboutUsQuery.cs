using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.AboutUs
{
    public class GetByIdAboutUsQuery : IRequest<IResult<DomainSuccess<GetByIdAboutUsResult>, DomainError>>
    {
        public int Id { get; set; }

        public GetByIdAboutUsQuery(int id)
        {
            Id = id;
        }
    }
}
