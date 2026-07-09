using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Advice
{
    public class CreateAdviceCommand:IRequest<IResult<DomainSuccess<CreateAdviceResult>,DomainError>>
    {
     
        public string AdviceTitle { get; set; }
        public IFormFile AdviceImage { get; set; }
        public string AdviceDescription { get; set; }
        public string AdviceContent { get; set; }
        public string AdviceDuration { get; set; }
    }
}
