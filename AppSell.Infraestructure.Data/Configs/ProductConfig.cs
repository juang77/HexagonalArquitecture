using AppSell.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSell.Infraestructure.Data.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("tblProducts");
        builder.HasKey(c => c.productId);

        builder
           .HasMany(product => product.sellDetails)
           .WithOne(detail => detail.Product);
    }
}
