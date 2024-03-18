using Microsoft.EntityFrameworkCore;
using MNHospital.Application.Abstraction.Repositories;
using MNHospital.Domain.Entities;
using MNHospital.Persistence.Contexts;
using System.Linq.Expressions;

namespace MNHospital.Persistence.Repositories;

public class ReadRepository<T>(MNHospitalDBContext context) : IReadRepository<T> where T : class, IEntity, new()
{
    public DbSet<T> Table => context.Set<T>();

    public IQueryable<T> GetAll(bool isTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table.AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return isTracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetAllExpression(int take, int skip, Expression<Func<T, bool>>? expression = null, bool isTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table.AsQueryable();
        if (expression is not null)
        {
            query = query.Where(expression);
        }

        query = query.Skip(skip).Take(take);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return isTracking ? query : query.AsNoTracking();
    }

    public IQueryable<T> GetAllExpressionOrderBy(int take, int skip, Expression<Func<T, object>> orderByExpression, bool isOrderByAsc = true, Expression<Func<T, bool>>? expression = null, bool isTracking = false, params string[] includes)
    {
        IQueryable<T> query = Table.AsQueryable();
        if (expression is not null)
        {
            query = query.Where(expression);
        }

        query = isOrderByAsc ? query.OrderBy(orderByExpression) : query.OrderByDescending(orderByExpression);
        query = query.Skip(skip).Take(take);
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return isTracking ? query : query.AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Table.FindAsync(id);
    }

    public Task<T?> GetBySingleExpressionAsync(Expression<Func<T, bool>> expression, bool isTracking = false)
    {
        IQueryable<T> query = Table.Where(expression);
        query = isTracking ? query : query.AsNoTracking();
        var response = query.FirstOrDefaultAsync();
        return response;
    }
}
