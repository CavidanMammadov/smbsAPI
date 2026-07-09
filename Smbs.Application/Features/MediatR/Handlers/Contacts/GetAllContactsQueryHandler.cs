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
    public class GetAllContactsQueryHandler(IRepository<Contact> repository) : IRequestHandler<GetAllContactsQuery, IResult<DomainSuccess<List<ResultContactDto>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<ResultContactDto>>, DomainError>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await repository.GetAll();
            if (contacts == null)
            {
                return Result.Fail<List<ResultContactDto>>(DomainError.NotFound("No contacts found"));
            }
            return Result.Success(DomainSuccess<List<ResultContactDto>>.OK(contacts.Select(contact => new ResultContactDto
            {
                ContactId = contact.ContactId,
                ContactEmail = contact.ContactEmail,
                ContactPhoneNumber = contact.ContactPhoneNumber,
                ContactLocation = contact.ContactLocation
            }).ToList(), "Retrieved successfully"));
        }
    }
}
