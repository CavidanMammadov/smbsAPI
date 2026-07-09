using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}
