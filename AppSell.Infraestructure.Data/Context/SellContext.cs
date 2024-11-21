using AppSell.Dominio.Entities;
using AppSell.Infraestructure.Data.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppSell.Infraestructure.Data.Context;

public class SellContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Sell> Sells { get; set; }

    public DbSet<SellDetail> SellDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = SellsDB; Integrated Security = true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ProductConfig());
        modelBuilder.ApplyConfiguration(new SellConfig());
        modelBuilder.ApplyConfiguration(new SellDetailConfig());
    }
}
