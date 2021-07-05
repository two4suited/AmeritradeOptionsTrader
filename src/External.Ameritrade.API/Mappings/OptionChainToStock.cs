using Core.Models;
using External.Ameritrade.API.Models.Options;

namespace External.Ameritrade.API.Mappings
{
    public class OptionChainToStock
    {
        private OptionChain _optionChain;        
        public OptionChainToStock(OptionChain optionChain)
        {            
            this._optionChain = optionChain;

        }

        public Stock MapToStock()
        {
            var stock = new Stock();

            stock.Symbol = _optionChain.Symbol;
            stock.Price = _optionChain.UnderlyingPrice;

            return stock;
        }
    }
}