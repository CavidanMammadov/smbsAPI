using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.BlogModules
{
    public class DeleteBlogModuleCommand:IRequest<IResult<DomainSuccess<int>,DomainError>>
    {
        public int Id { get; set; }

        public DeleteBlogModuleCommand(int id)
        {
            Id = id;
        }
    }
}
