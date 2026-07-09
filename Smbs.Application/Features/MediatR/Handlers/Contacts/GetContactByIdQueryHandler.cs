using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Contacts;
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
    public class GetContactByIdQueryHandler(IRepository<Contact> repository) : IRequestHandler<GetContactByIdQuery, IResult<DomainSuccess<ResultContactDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultContactDto>, DomainError>> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact=await repository.GetById(request.Id);
            if (contact == null)
            {
                return Result.Fail<ResultContactDto>(DomainError.NotFound("Contact not found"));
            }
            return Result.Success(DomainSuccess<ResultContactDto>.OK(new ResultContactDto
            {ContactId = contact.ContactId,
                ContactEmail = contact.ContactEmail,
                ContactPhoneNumber = contact.ContactPhoneNumber,
                ContactLocation = contact.ContactLocation
            }, "Retrieved successfully"));
        }
    }
}
