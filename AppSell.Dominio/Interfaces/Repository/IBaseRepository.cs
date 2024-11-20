using AppSell.Dominio.Interfaces;

namespace AppSell.Dominio.Interfaces.Repository;

public interface IBaseRepository<TEntity, TEntityID>: IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IListApp<TEntity, TEntityID>, ITransaction
{

}
