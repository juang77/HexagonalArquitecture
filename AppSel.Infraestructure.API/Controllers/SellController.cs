using AppSell.Applications.Services;
using AppSell.Dominio.Entities;
using AppSell.Infraestructure.Data.Context;
using AppSell.Infraestructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AppSel.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellController : ControllerBase
    {
        SellService CreateService()
        {
            SellContext db = new SellContext();
            SellRepository SellRepository = new SellRepository(db);
            ProductRepository productRepository = new ProductRepository(db);
            SellDetailRepository sellDetailRepository = new SellDetailRepository(db);
            SellService Service = new SellService(productRepository, SellRepository, sellDetailRepository);
            return Service;
        }

        [HttpGet]
        public ActionResult<List<Sell>> Get()
        {
            var service = CreateService();
            return Ok(service.ListApp());
        }

        [HttpGet("{id}")]
        public ActionResult<Sell> GetById(Guid id)
        {
            var service = CreateService();
            return Ok(service.SelectById(id));
        }

        [HttpPost]
        public ActionResult Add([FromBody] Sell sell)
        {
            var service = CreateService();
            service.Add(sell);
            return Ok("Added satisfactory!!!!!");
        }

        [HttpPut]
        public ActionResult Cancel(Guid id)
        {
            var service = CreateService();
            service.Cancel(id);
            return Ok("Canceled satisfactory!!!!!");
        }
    }
}
