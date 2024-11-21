using AppSell.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppSell.Infraestructure.Data.Configs;

public class SellConfig : IEntityTypeConfiguration<Sell>
{
    public void Configure(EntityTypeBuilder<Sell> builder)
    {
        builder.ToTable("tblSells");
        builder.HasKey(c => c.sellId);

        builder
          .HasMany(sell => sell.sellDetails)
          .WithOne(detail => detail.Sell);
    }
}
