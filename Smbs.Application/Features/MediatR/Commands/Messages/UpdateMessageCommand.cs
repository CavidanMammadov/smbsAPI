using FluentValidation;
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
    public class UpdateMessageCommand:IRequest<IResult<DomainSuccess<MessageResult>,DomainError>>
    {
        public int MessageId { get; set; }
        public string MessageNameAndSurname { get; set; }
        public string MessageEmail { get; set; }
        public string MessagePhoneNumber { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
    }
    public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommand>
    {
        public UpdateMessageCommandValidator()
        {
            RuleFor(a => a.MessageNameAndSurname).NotEmpty().WithMessage("MessageNameandSurname cannot be empty");
            RuleFor(a => a.MessagePhoneNumber).NotEmpty().WithMessage("MessagePhoneNumber cannot be empty");
            RuleFor(a => a.MessageEmail).NotEmpty().WithMessage("Messagemail cannot be empty");
            RuleFor(a => a.MessageContent).NotEmpty().WithMessage("MessageContent cannot be empty");
        }
    }
}
