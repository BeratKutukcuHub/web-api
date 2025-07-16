
using Entities;
using Entities.Exceptions;
using Repositories.Contract;
using Services.Contract;

namespace Services.EfCore;

public class ProductManager : IProductManager<Product>
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ILoggerService _logger;
    public ProductManager(IRepositoryManager repositoryManager, ILoggerService logger)
    {
        _repositoryManager = repositoryManager;
        _logger = logger;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        _logger.LogInfo("Kullanıcı ürün verilerini görüntüledi");
       return _repositoryManager._repositoryBase.FindAll(false);
    }
    public Product GetProduct(int id)
    {
        var entity = _repositoryManager._repositoryBase.
        FindByCondition(repo => repo.id.Equals(id), false).
        FirstOrDefault();
        if (entity == null)
        {
            _logger.LogWarn("Böyle bir kullanıcı mevcut değil.");
            throw new ProductNotFoundException(entity.id);
        }
        else _logger.LogInfo($"{id}'ye sahip ürün görüntülendi");
        return entity;
    }
    public void CreateProduct(Product entity)
    {
        if (entity == null)
        {
            throw new ProductNotFoundException(0);
        }
         _logger.LogInfo("Ürün eklemesi gerçekleşti");
        _repositoryManager._repositoryBase.Create(entity);
        _repositoryManager.SaveChanges();
    }
    public void DeleteProduct(int id)
    {
        _logger.LogDebug($"{id}'ye sahip ürün silindi/listeden çıkartıldı");
        _repositoryManager._repositoryBase.Delete(id);
        _repositoryManager.SaveChanges();
    }
    public void UpdateProduct(Product entity) => _repositoryManager._repositoryBase.Update(entity); 
}