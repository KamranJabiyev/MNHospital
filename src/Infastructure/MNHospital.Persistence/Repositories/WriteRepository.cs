using Microsoft.EntityFrameworkCore;
using MNHospital.Application.Abstraction.Repositories;
using MNHospital.Domain.Entities;
using MNHospital.Persistence.Contexts;

namespace MNHospital.Persistence.Repositories;

public class WriteRepository<T>(MNHospitalDBContext context) : IWriteRepository<T> where T : class, IEntity, new()
{
    public DbSet<T> Table => context.Set<T>();

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(ICollection<T> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public void Remove(T entity)
    {
        Table.Remove(entity);
    }

    public void RemoveRange(ICollection<T> entities)
    {
        Table.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        Table.Update(entity);
        //context.Entry<T>(entity).State = EntityState.Modified;
    }

    public async Task SaveChangeAsync()
    {
        await context.SaveChangesAsync();
    }
}
