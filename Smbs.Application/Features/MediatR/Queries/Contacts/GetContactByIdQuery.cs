using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Contacts;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Contacts
{
    public class GetContactByIdQuery:IRequest<IResult<DomainSuccess<ResultContactDto>,DomainError>>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }
}
