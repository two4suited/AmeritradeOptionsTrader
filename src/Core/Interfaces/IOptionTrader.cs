using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces
{
    public interface IOptionTrader
    {
         OptionTransaction SellOptionContract(Stock stock,ContractSellConfiguration configuration,OptionType optionType);
         OptionTransaction CloseOptionContract(Stock option,ContractCloseConfiguration configuration, OptionType optionType);
    }
}
