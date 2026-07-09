using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class GetAllMessagesQueryHandler(IRepository<Message> repository) : IRequestHandler<GetAllMessageQuery, IResult<DomainSuccess<List<MessageResult>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<MessageResult>>, DomainError>> Handle(GetAllMessageQuery request, CancellationToken cancellationToken)
        {
            var result =await repository.GetAll();
            if (result == null)
            {
                return Result.Fail<List<MessageResult>>(DomainError.NotFound("Messages not found"));
            }
            return Result.Success<List<MessageResult>>(DomainSuccess<List<MessageResult>>.OK(result.Select(a => new MessageResult
            {
                MessageId = a.MessageId,
                MessageContent = a.MessageContent,
                MessageNameAndSurname = a.MessageNameAndSurname,
                MessageEmail = a.MessageEmail,
                MessageSubject = a.MessageSubject,
                MessagePhoneNumber = a.MessagePhoneNumber
            }).ToList()));
        }
    }
}
