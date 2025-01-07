using Finshark.Data;
using Finshark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StockController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _applicationDbContext
                .Stocks
                .ToList()
                .Select(s => s.ToDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _applicationDbContext
                .Stocks
                .Find(id)
                .ToDto();

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
    }
}
