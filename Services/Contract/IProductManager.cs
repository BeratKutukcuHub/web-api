using Entities;

namespace Services.Contract;

public interface IProductManager<T>
{
    IEnumerable<T> GetAllBooks();
    Product GetProduct(int id);
    void CreateProduct(T entity);
    void DeleteProduct(int id);
    void UpdateProduct(T entity); 
}