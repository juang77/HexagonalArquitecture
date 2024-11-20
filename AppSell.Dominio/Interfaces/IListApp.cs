namespace AppSell.Dominio.Interfaces;

public interface IListApp<IEntity, TEntityID>
{
    List<IEntity> ListApp();

    IEntity SelectById(TEntityID entityID);
}
