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
    public class UpdateMessageCommandHandler(IRepository<Message> repository) : IRequestHandler<UpdateMessageCommand, IResult<DomainSuccess<MessageResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MessageResult>, DomainError>> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
        {
            var message =await repository.GetById(request.MessageId);
            if (message == null)
            {
                Result.Fail<MessageResult>(DomainError.NotFound("Message not found"));
            }
            await repository.Update(new Message
            {
                MessageId = request.MessageId,
                MessageContent = request.MessageContent,
                MessageNameAndSurname = request.MessageNameAndSurname,
                MessageEmail = request.MessageEmail,
                MessagePhoneNumber = request.MessagePhoneNumber,
                MessageSubject = request.MessageSubject,
            });
            return Result.Success<MessageResult>(DomainSuccess<MessageResult>.OK(new MessageResult
            {
                MessageId = request.MessageId,
                MessageSubject = request.MessageSubject,
                MessageContent = request.MessageContent,
                MessagePhoneNumber = request.MessagePhoneNumber,
                MessageEmail = request.MessageEmail,
                MessageNameAndSurname = request.MessageNameAndSurname,
            },"Updated successfully"));
        }
    }
}
