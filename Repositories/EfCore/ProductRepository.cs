using Entities;
using Repositories.Contract;

namespace Repositories.EfCore;

public class ProductRepository : RepositoryBase<Product>, IProductRepository
{
    public ProductRepository(RepositoryContext repo) : base(repo)
    {
    }
}