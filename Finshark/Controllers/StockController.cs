using Finshark.Data;
using Finshark.Dtos.Stock;
using Finshark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Finshark.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context
                .Stocks
                .ToList()
                .Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context
                .Stocks
                .Find(id)
                .ToStockDto();

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequest stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }
    }
}
