using AppSell.Dominio.Interfaces;

namespace AppSell.Dominio.Interfaces.Repository;

public interface IRepositoryMovimiento<TEntity, TEntityID>: IAdd<TEntity>, IListApp<TEntity, TEntityID>, ITransaction
{
    void Cancel(TEntityID entityId);
}
