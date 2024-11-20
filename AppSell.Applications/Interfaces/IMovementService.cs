using AppSell.Dominio.Interfaces;

namespace AppSell.Applications.Interfaces;

public interface IMovementService<TEntity, TEntityID> : IAdd<TEntity>, IListApp<TEntity, TEntityID>
{
    void Cancel(TEntityID entityId);
}
