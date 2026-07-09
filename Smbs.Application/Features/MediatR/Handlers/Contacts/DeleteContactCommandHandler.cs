using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Contacts;
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
    public class DeleteContactCommandHandler(IRepository<Contact> repository) : IRequestHandler<DeleteContactCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact=await repository.GetById(request.Id);
            if (contact==null)
            {
                return Result.Fail<int>(DomainError.ServerError("Contact not found"));  
            }
            await repository.Delete(contact);
            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
