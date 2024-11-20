using AppSell.Dominio.Interfaces;

namespace AppSell.Applications.Interfaces;

public interface IBaseService<TEntity, TEntityID> : IAdd<TEntity>, IEdit<TEntity>, IDelete<TEntityID>, IListApp<TEntity, TEntityID>
{

}
