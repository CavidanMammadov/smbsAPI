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
    public class UpdateContactCommandHandler(IRepository<Contact> repository) : IRequestHandler<UpdateContactCommand, IResult<DomainSuccess<ResultContactDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultContactDto>, DomainError>> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact =await repository.GetById(request.ContactId);
            if (contact == null)
            {
                return Result.Fail<ResultContactDto>(DomainError.NotFound("Contact not found"));
            }
           contact.ContactEmail = request.ContactEmail;
            contact.ContactPhoneNumber = request.ContactPhoneNumber;
            contact.ContactLocation = request.ContactLocation;
            await repository.Update(contact);
            return Result.Success(DomainSuccess<ResultContactDto>.OK(new ResultContactDto
            {
                ContactId = request.ContactId,
                ContactEmail = request.ContactEmail,
                ContactPhoneNumber = request.ContactPhoneNumber,
                ContactLocation = request.ContactLocation
            }, "Updated successfully"));
        }
    }
}
