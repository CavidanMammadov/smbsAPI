using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class TrainingRepository : Repository<Training> , ITrainingRepository
{
    public TrainingRepository(AppDbContext context) : base(context)
    {
    }
}
