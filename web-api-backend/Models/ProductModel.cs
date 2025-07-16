namespace Backend.Models;
public class ProductModel
{
    public string productName { get; set; } = string.Empty;
    public string productCode {get; set;} = string.Empty;
    public double productPrice {get; set;}
    public int CategoryId { get; set; }
}