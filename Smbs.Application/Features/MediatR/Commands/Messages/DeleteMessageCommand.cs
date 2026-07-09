using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Messages;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Messages
{
    public class DeleteMessageCommand:IRequest<IResult<DomainSuccess<int>,DomainError>>
    {
        public int Id { get; set; }

        public DeleteMessageCommand(int id)
        {
            Id = id;
        }
    }
}
