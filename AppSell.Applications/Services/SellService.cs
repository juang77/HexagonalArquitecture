using AppSell.Applications.Interfaces;
using AppSell.Dominio.Entities;
using AppSell.Dominio.Interfaces.Repository;

namespace AppSell.Applications.Services
{
    public class SellService : IMovementService<Sell, Guid>
    {
        private readonly IRepositoryMovement<Sell, Guid> _repositorySell;
        private readonly IBaseRepository<Product, Guid> _repositoryProduct;
        private readonly IRepositorySellDetail<SellDetail, Guid> _repositorySellDetail;

        public SellService(IBaseRepository<Product, Guid> repositoryProduct, IRepositoryMovement<Sell, Guid> repositorySell, IRepositorySellDetail<SellDetail, Guid> repositorySellDetail)
        {

            _repositoryProduct = repositoryProduct;
            _repositorySell = repositorySell;
            _repositorySellDetail = repositorySellDetail;
        }

        public Sell Add(Sell entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Sell is Required");

            var resultSell = _repositorySell.Add(entity);

            entity.sellDetails.ForEach(detail => {

                var selectedProduct = _repositoryProduct.SelectById(detail.productId);
                if (selectedProduct == null)
                    throw new ArgumentNullException("Product is Required");

                detail.unitCost = selectedProduct.cost;
                detail.unitPrice = selectedProduct.prise;
                detail.sellCuantity = detail.sellCuantity;
                detail.subTotalDS = detail.unitPrice * detail.sellCuantity;
                detail.taxDS = (detail.subTotalDS * 19) / 100;
                detail.totalDS = detail.subTotalDS + detail.taxDS;
                _repositorySellDetail.Add(detail);

                selectedProduct.stock -= detail.sellCuantity;
                _repositoryProduct.Edit(selectedProduct);
                entity.subTotalSell += detail.subTotalDS;
                entity.taxSell += detail.taxDS;
                entity.totalSell += detail.totalDS;
            });
            _repositorySell.SaveAll();
            return entity;
        }

        public void Cancel(Guid entityId)
        {
            _repositorySell.Cancel(entityId);
            _repositorySell.SaveAll();
        }

        public List<Sell> ListApp()
        {
            return _repositorySell.ListApp();
        }

        public Sell SelectById(Guid entityID)
        {
            return _repositorySell.SelectById(entityID);
        }
    }
}
