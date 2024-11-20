namespace AppSell.Dominio.Interfaces;

public interface IListApp<IEntity, TEntityID>
{
    List<IEntity> List();

    IEntity SelectById(TEntityID entityID);
}
