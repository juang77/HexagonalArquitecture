using AppSell.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSell.Infraestructure.Data.Configs;

public class SellDetailConfig : IEntityTypeConfiguration<SellDetail>
{
    public void Configure(EntityTypeBuilder<SellDetail> builder)
    {
        builder.ToTable("tblSellDetail");
        builder.HasKey(c => new { c.productId, c.sellId });

        builder
            .HasOne(detail => detail.Product)
            .WithMany(product => product.sellDetails);

        builder
            .HasOne(detail => detail.Sell)
            .WithMany(sell => sell.sellDetails);
    }
}
