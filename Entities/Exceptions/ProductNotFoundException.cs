namespace Entities.Exceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(int id) : base($"The product {id} could not found")
    {
    }
}