using Microsoft.Extensions.DependencyInjection;
using Repositories.Contract;

namespace Repositories.EfCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private Lazy<IProductRepository> _repositoryBaseLazy {get;} 
    public IProductRepository _repositoryBase => _repositoryBaseLazy.Value;
    public RepositoryManager(RepositoryContext repositoryContext, IServiceProvider sp)
    {
        _repositoryContext = repositoryContext;
        _repositoryBaseLazy =
        new Lazy<IProductRepository>(() => sp.GetRequiredService<IProductRepository>());
    }
    
    public void SaveChanges()
    {
        _repositoryContext.SaveChanges();
    }
}
