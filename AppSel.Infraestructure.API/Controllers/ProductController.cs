using AppSell.Applications.Services;
using AppSell.Dominio.Entities;
using AppSell.Infraestructure.Data.Context;
using AppSell.Infraestructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppSel.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        ProductService CreateService() { 
            SellContext db = new SellContext();
            ProductRepository repo = new ProductRepository(db);
            ProductService productService = new ProductService(repo);
            return productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service.ListApp());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectById(id));
        }

        [HttpPost]
        public ActionResult Add([FromBody] Product product)
        {
            var service = CreateService();
            service.Add(product);
            return Ok("Added satisfactory!!!!!");
        }

        [HttpPut]
        public ActionResult Edit(Guid id, [FromBody] Product product)
        {
            var service = CreateService();
            product.productId = id;
            service.Edit(product);
            return Ok("Edited satisfactory!!!!!");
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Correctly deleted!!!!!");
        }
    }
}
