namespace Entities;

public class Product : Id
{
    public string productName { get; set; } = string.Empty;
    public string productCode {get; set;} = string.Empty;
    public double productPrice {get; set;}
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}