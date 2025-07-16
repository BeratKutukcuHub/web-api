using Entities;
using Repositories.Contract;
using Services.Contract;

namespace Services.EfCore;

public class ServiceManager : IServiceManager
{
    public IRepositoryManager _manager { get; }

    public IProductManager<Product> _productManager { get; }

    public ServiceManager(IRepositoryManager manager, IProductManager<Product> productManager)
    {
        _manager = manager;
        _productManager = productManager;
    }
}