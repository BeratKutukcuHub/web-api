
using Entities;
using Repositories.Contract;
using Services.Contract;

namespace Services.EfCore;

public class ProductManager : IProductManager<Product>
{
    private readonly IRepositoryManager _repositoryManager;

    public ProductManager(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }
    public IEnumerable<Product> GetAllBooks() => _repositoryManager._repositoryBase.FindAll(false);
    public Product GetProduct(int id) =>_repositoryManager._repositoryBase.
    FindByCondition(repo => repo.id.Equals(id), false).
    FirstOrDefault();
    public void CreateProduct(Product entity) => _repositoryManager._repositoryBase.Create(entity);
    public void DeleteProduct(int id) => _repositoryManager._repositoryBase.Delete(id);
    public void UpdateProduct(Product entity) => _repositoryManager._repositoryBase.Update(entity); 
}