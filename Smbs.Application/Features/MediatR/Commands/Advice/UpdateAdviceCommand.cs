using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;

namespace Smbs.Application.Features.MediatR.Commands.Advice
{
    public class UpdateAdviceCommand : IRequest<IResult<DomainSuccess<CreateAdviceResult>, DomainError>>
    {
        public int AdviceId { get; set; }
        public string AdviceTitle { get; set; }
        public IFormFile AdviceImage { get; set; }
        public string AdviceDescription { get; set; }
        public string AdviceContent { get; set; }
        public string AdviceDuration { get; set; }
    }
}
