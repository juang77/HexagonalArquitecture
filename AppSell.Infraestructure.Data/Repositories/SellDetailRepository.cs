using AppSell.Dominio.Entities;
using AppSell.Dominio.Interfaces.Repository;
using AppSell.Infraestructure.Data.Context;

namespace AppSell.Infraestructure.Data.Repositories
{
    internal class SellDetailRepository : IRepositorySellDetail<SellDetail, Guid>
    {
        private SellContext _db;

        public SellDetailRepository(SellContext db)
        {
            _db = db;
        }

        public SellDetail Add(SellDetail entity)
        {
            _db.SellDetails.Add(entity);
            return entity;
        }

        public void SaveAll()
        {
            _db.SaveChanges();
        }
    }
}
