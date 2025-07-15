using Entities;

namespace Repositories.Contract;

public interface IRepositoryManager
{
    IProductRepository _repositoryBase { get;}
    void SaveChanges();
}