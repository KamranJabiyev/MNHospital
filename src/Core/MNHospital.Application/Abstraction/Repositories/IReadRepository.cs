using MNHospital.Domain.Entities;
using System.Linq.Expressions;

namespace MNHospital.Application.Abstraction.Repositories;

public interface IReadRepository<T>:IRepository<T> where T : class,IEntity,new()
{
    Task<T> GetByIdAsync(Guid Id);
    Task<T> GetByExpressionAsync(Expression<Func<T,bool>> expression,bool isTracking=false);
    IQueryable<T> GetAll(bool isTracking = false,params string[] includes);
    IQueryable<T> GetAllExpression(int take,int skip, Expression<Func<T, bool>>? expression=null, bool isTracking = false,params string[] includes);
    IQueryable<T> GetAllExpressionOrderBy(int take,int skip, Expression<Func<T, object>> orderByExpression,bool isOrderByAsc=true, Expression<Func<T, bool>>? expression=null, bool isTracking = false,params string[] includes);
}
