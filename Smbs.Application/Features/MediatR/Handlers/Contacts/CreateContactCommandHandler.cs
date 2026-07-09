using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Contacts;
using Smbs.Application.Features.MediatR.Results.Contacts;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Contacts
{
    public class CreateContactCommandHandler(IRepository<Contact> repository) : IRequestHandler<CreateContactCommand, IResult<DomainSuccess<ResultContactDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultContactDto>, DomainError>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                ContactEmail = request.ContactEmail,
                ContactPhoneNumber = request.ContactPhoneNumber,
                ContactLocation = request.ContactLocation

            };
            await repository.Create(contact);
            return Result.Success(DomainSuccess<ResultContactDto>.Created(new ResultContactDto
            {
                ContactId = contact.ContactId,
                ContactEmail = request.ContactEmail,
                ContactPhoneNumber = request.ContactPhoneNumber,
                ContactLocation = request.ContactLocation
            }, "Created successfully"));
        }
    }
}
