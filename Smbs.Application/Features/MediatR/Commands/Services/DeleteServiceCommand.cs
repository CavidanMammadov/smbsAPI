using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Services
{
    public class DeleteServiceCommand:IRequest<IResult<DomainSuccess<int>,DomainError>>
    {
        public int Id { get; set; }

        public DeleteServiceCommand(int id)
        {
            Id = id;
        }
    }
}
