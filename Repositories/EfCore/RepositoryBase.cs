using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contract;

namespace Repositories.EfCore;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: Id
{
    protected RepositoryContext _repo;
    public RepositoryBase(RepositoryContext repo)
    {
        _repo = repo;
    }

    public void Create(T entity)
    {
        _repo.Set<T>().Add(entity);
    }
    public void Delete(int Id)
    {
        var entity = _repo.Set<T>().FirstOrDefault(entity => entity.id == Id);
        _repo.Set<T>().Remove(entity);
    }
    public IQueryable<T> FindAll(bool changeTracker) =>
        changeTracker ? _repo.Set<T>() : _repo.Set<T>().AsNoTracking();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool changeTracker) =>
        changeTracker ? _repo.Set<T>().Where(expression) 
        : _repo.Set<T>().AsNoTracking().Where(expression);

    public void Update(T entity)
    {
        var entit = _repo.Set<T>().FirstOrDefault(entity);
        _repo.Set<T>().Update(entity);
    }
}
