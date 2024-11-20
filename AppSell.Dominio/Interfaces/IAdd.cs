namespace AppSell.Dominio.Interfaces;

public interface IAdd<TEntity>
{
    TEntity Add(TEntity entity);
}
