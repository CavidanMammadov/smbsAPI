using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.AboutUs;
using Smbs.Application.Features.MediatR.Queries.Messages;
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
    public class GetByIdMessageQueryHandler(IRepository<Message> repository) : IRequestHandler<GetByIdMessageQuery, IResult<DomainSuccess<MessageResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<MessageResult>, DomainError>> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
        {
            var message =await repository.GetById(request.Id);
            if (message == null)
            {
                return Result.Fail<MessageResult>(DomainError.NotFound("Message not found in given id"));
            }
            return Result.Success<MessageResult>(DomainSuccess<MessageResult>.OK(new MessageResult
            {MessageId = message.MessageId,
                MessageContent = message.MessageContent,
                MessageEmail = message.MessageEmail,
                MessageNameAndSurname = message.MessageNameAndSurname,
                MessagePhoneNumber = message.MessagePhoneNumber,
                MessageSubject = message.MessageSubject,
            }));
        }
    }
}
