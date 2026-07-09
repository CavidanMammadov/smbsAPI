using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class TrainerRespository : Repository<Trainer>, ITrainerRespository
{
    public TrainerRespository(AppDbContext context) : base(context)
    {
    }
}
