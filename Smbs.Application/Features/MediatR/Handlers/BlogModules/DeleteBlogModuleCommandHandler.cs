using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.BlogModules;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.BlogModules
{
    public class DeleteBlogModuleCommandHandler(IRepository<BlogModule> repository) : IRequestHandler<DeleteBlogModuleCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteBlogModuleCommand request, CancellationToken cancellationToken)
        {
            var value= await repository.GetById(request.Id);
            if(value == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Cant be found in this id"));
            }
            await repository.Delete(value);
            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
