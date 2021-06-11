using System.Collections.Generic;
using Core.Models;

namespace Core.Interfaces
{
    public interface IOptionTrader
    {
         Option SellOptionContract(List<Option> Options,ContractSellConfiguration configuration,OptionType optionType);
         Option CloseOptionContract(Option option,ContractCloseConfiguration configuration, OptionType optionType);
    }
}
