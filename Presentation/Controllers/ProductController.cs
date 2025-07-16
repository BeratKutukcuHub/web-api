using Entities;
using Microsoft.AspNetCore.Mvc;
using Presantation.Models;
using Services.Contract;

namespace Presantation.Controller;

[ApiController]
[Route("v2/product")]
public class ProductController : ControllerBase
{
    private readonly IServiceManager _service;

    public ProductController(IServiceManager service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetProdcuts()
    {
        var products = _service._productManager.GetAllProducts();
        return Ok(products);
    }
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _service._productManager.GetProduct(id);
        return Ok(product);
    }
    [HttpPost]
    public IActionResult CreateProduct(ProductModel modelEntity)
    {
        _service._productManager.CreateProduct(new Product
        {
            productName = modelEntity.productName,
            CategoryId = modelEntity.CategoryId,
            productCode = modelEntity.productCode,
            productPrice = modelEntity.productPrice,
        });
        return Ok(modelEntity);
    }
}