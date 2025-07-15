using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace Repositories.Config;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product()
            {
                id = 1,
                productName = "Excalibur 5070/SX",
                CategoryId = 1,
                productCode = "PC001"
            },
            new Product()
            {
                id = 2,
                productName = "PRO 2000/SCE80",
                CategoryId = 1,
                productCode = "PC002"
            },
            new Product()
            {
                id = 3,
                productName = "Monster Notebook 8050",
                CategoryId = 1,
                productCode = "PC003"
            }
        );
        builder.HasKey(pro => pro.id);
    }
}
