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

                var newDetail = new SellDetail();
                newDetail.sellId = detail.sellId;
                newDetail.productId = detail.productId;
                newDetail.unitCost = selectedProduct.cost;
                newDetail.unitPrice = selectedProduct.prise;
                newDetail.sellCuantity = detail.sellCuantity;
                newDetail.subTotalDS = newDetail.unitPrice * newDetail.sellCuantity;
                newDetail.taxDS = (newDetail.subTotalDS * 19) / 100;
                newDetail.totalDS = newDetail.subTotalDS + newDetail.taxDS;
                _repositorySellDetail.Add(newDetail);

                selectedProduct.stock -= newDetail.sellCuantity;
                _repositoryProduct.Edit(selectedProduct);
                entity.subTotalSell += newDetail.subTotalDS;
                entity.taxSell += newDetail.taxDS;
                entity.totalSell += newDetail.totalDS;
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
