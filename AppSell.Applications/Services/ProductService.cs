using AppSell.Applications.Interfaces;
using AppSell.Dominio.Entities;
using AppSell.Dominio.Interfaces.Repository;

namespace AppSell.Applications.Services;

public class ProductService : IBaseService<Product, Guid>
{
    private readonly IBaseRepository<Product, Guid> _repository;

    public ProductService(IBaseRepository<Product, Guid> repository) 
    {
        _repository = repository;
    }

    public Product Add(Product entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Product is Required");

        var resultProduct = _repository.Add(entity);
        _repository.SaveAll();
        return resultProduct;
    }

    public void Delete(Guid entityId)
    {
        _repository.Delete(entityId);
        _repository.SaveAll();
    }

    public void Edit(Product entity)
    {
        if (entity == null)
            throw new ArgumentNullException("Product is Required");

        _repository.Edit(entity);
        _repository.SaveAll();
    }

    public List<Product> ListApp()
    {
        return _repository.ListApp();
    }

    public Product SelectById(Guid entityID)
    {
        return _repository.SelectById(entityID);
    }
}
