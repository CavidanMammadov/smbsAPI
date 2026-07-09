using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Certificates;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Certificates
{
    public class GetCertificateByIdQuery:IRequest<IResult<DomainSuccess<CertificateResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetCertificateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
