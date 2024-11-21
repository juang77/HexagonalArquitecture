using AppSell.Dominio.Entities;
using AppSell.Dominio.Interfaces.Repository;
using AppSell.Infraestructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AppSell.Infraestructure.Data.Repositories
{
    public class SellRepository : IRepositoryMovement<Sell, Guid>
    {
        private SellContext _db;

        public SellRepository(SellContext db)
        {
            _db = db;
        }

        public Sell Add(Sell entity)
        {
            entity.sellId = Guid.NewGuid();
            _db.Sells.Add(entity);
            return entity;
        }

        public void Cancel(Guid entityId)
        {
            var selectedSell = _db.Sells.Where(c => c.sellId == entityId).FirstOrDefault();
            if (selectedSell == null)
            {
                throw new NullReferenceException("You are trying delete an unexistent sell");
            }
            selectedSell.Canceled = true;
            _db.Entry(selectedSell).State = EntityState.Modified;
        }

        public List<Sell> ListApp()
        {
            return _db.Sells.ToList();
        }

        public void SaveAll()
        {
            _db.SaveChanges();
        }

        public Sell SelectById(Guid entityID)
        {
            var selectedSell = _db.Sells.Where(c => c.sellId == entityID).FirstOrDefault();
            return selectedSell;
        }
    }
}
