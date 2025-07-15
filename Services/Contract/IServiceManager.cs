using Entities;
using Repositories.Contract;

namespace Services.Contract;

public interface IServiceManager
{
    IRepositoryManager _manager { get; }
    IProductManager<Product> _productManager { get; }
}