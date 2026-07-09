using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Messages;
using Smbs.Application.Features.MediatR.Results.Messages;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Messages
{
    public class DeleteMessageCommandHandler(IRepository<Message> repository) : IRequestHandler<DeleteMessageCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            var message =await repository.GetById(request.Id);
            if (message == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Message not found in given id"));
            }
           await repository.Delete(message);
            return Result.Success<int>(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
