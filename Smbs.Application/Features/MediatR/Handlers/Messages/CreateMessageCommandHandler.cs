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
    public class CreateMessageCommandHandler(IRepository<Message> repository) : IRequestHandler<CreateMessageCommand, IResult<DomainSuccess<MessageResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MessageResult>, DomainError>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                MessageContent = request.MessageContent,
                MessageEmail = request.MessageEmail,
                MessageNameAndSurname = request.MessageNameAndSurname,
                MessagePhoneNumber = request.MessagePhoneNumber,
                MessageSubject = request.MessageSubject,
            };
            await repository.Create(message);
            return Result.Success<MessageResult>(DomainSuccess<MessageResult>.Created(new MessageResult
            {
                MessageId = message.MessageId,
                MessageContent = request.MessageContent,
                MessageEmail = request.MessageEmail,
                MessageSubject = request.MessageSubject,
                MessagePhoneNumber = request.MessagePhoneNumber,
                MessageNameAndSurname = request.MessageNameAndSurname,
            }, "Created Successfully"));
        }
    }
}
