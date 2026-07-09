using MediatR;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Trainings
{
    public class GetAllTrainingsQuery:IRequest<IResult<DomainSuccess<List<TrainingResult>>,DomainError>>
    {
    }
}
