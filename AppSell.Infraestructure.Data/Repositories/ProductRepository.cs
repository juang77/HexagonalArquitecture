using AppSell.Dominio.Entities;
using AppSell.Dominio.Interfaces.Repository;
using AppSell.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AppSell.Infraestructure.Data.Repositories;

public class ProductRepository : IBaseRepository<Product, Guid>
{
    private SellContext _db;

    public ProductRepository(SellContext db)
    { 
        _db = db;
    }

    public Product Add(Product entity)
    {
        entity.productId = Guid.NewGuid();
        _db.Products.Add(entity);
        return entity;
    }

    public void Delete(Guid entityID)
    {
        var selectedProduct = _db.Products.Where(c => c.productId == entityID).FirstOrDefault();
        if (selectedProduct != null)
        {
            _db.Products.Remove(selectedProduct);
        }
    }

    public void Edit(Product entity)
    {
        var selectedProduct = _db.Products.Where(c => c.productId == entity.productId).FirstOrDefault();
        if (selectedProduct != null) 
        {
            selectedProduct.name = entity.name;
            selectedProduct.description = entity.description;
            selectedProduct.cost = entity.cost;
            selectedProduct.prise = entity.prise;
            selectedProduct.stock = entity.stock;
            
            _db.Entry(selectedProduct).State = EntityState.Modified;
        }
    }

    public List<Product> ListApp()
    {
        return _db.Products.ToList();
    }

    public void SaveAll()
    {
        _db.SaveChanges();
    }

    public Product SelectById(Guid entityID)
    {
        var selectedProduct = _db.Products.Where(c => c.productId == entityID).FirstOrDefault();
        return selectedProduct;
    }
}
