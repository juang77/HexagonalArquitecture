namespace AppSell.Dominio.Interfaces;

public interface IDelete<TEntityID>
{
    void Delete(TEntityID entityId);
}
