using Microsoft.EntityFrameworkCore;
using MNHospital.Domain.Entities;

namespace MNHospital.Application.Abstraction.Repositories;

public interface IRepository<T> where T : class,IEntity,new()
{
    public DbSet<T> Table { get; }
}
