using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category() { id = 1, categoryName = "Masaüstü Bilgisayar", categoryCode = "0001" },
            new Category() { id = 2, categoryName = "Dizüstü Bilgisayar", categoryCode = "0002" }
        );
        builder.HasKey(category => category.id);
    }
}
