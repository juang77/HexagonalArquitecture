using AppSell.Dominio.Interfaces;

namespace AppSell.Dominio.Interfaces.Repository;

public interface IRepositorySellDetail<TEntity, TMovimientoID>: IAdd<TEntity>, ITransaction
{

}
