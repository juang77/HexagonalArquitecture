namespace AppSell.Dominio.Interfaces.Repository;

public interface IRepositoryMovement<TEntity, TEntityID>: IAdd<TEntity>, IListApp<TEntity, TEntityID>, ITransaction
{
    void Cancel(TEntityID entityId);
}
