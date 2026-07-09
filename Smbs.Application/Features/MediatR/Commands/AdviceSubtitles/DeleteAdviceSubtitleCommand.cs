using MediatR;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.AdviceSubtitles
{
    public class DeleteAdviceSubtitleCommand:IRequest<IResult<DomainSuccess<int>, DomainError>>
    {
        public int Id { get; set; }

        public DeleteAdviceSubtitleCommand(int id)
        {
            Id = id;
        }
    }
}
