using System.Linq.Expressions;

namespace Repositories.Contract;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool changeTracker);
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool changeTracker);
    void Create(T entity);
    void Update(T entity);
    void Delete(int Id);
}