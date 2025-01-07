using Finshark.Dtos.Stock;
using Finshark.Models;

namespace Finshark.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToDto(this Stock stock)
        {
            return new StockDto
            {
                Id = stock.Id,
                Symbol = stock.Symbol,
                CompanyName = stock.CompanyName,
                Purchase = stock.Purchase,
                LastDiv = stock.LastDiv,
                Industry = stock.Industry,
                MarketCap = stock.MarketCap
            };
        }
    }
}
