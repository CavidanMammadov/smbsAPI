using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Students;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Students
{
    public class GetByIdStudentQuery:IRequest<IResult<DomainSuccess<StudentResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdStudentQuery(int id)
        {
            Id = id;
        }
    }
}
