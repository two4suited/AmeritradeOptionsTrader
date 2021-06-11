using System;
using System.Collections.Generic;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class OptionTrader : IOptionTrader
    {
        public OptionTrader()
        {
        }

        public Option CloseOptionContract(Option option, ContractCloseConfiguration configuration, OptionType optionType)
        {
            throw new NotImplementedException();
        }

        public Option SellOptionContract(List<Option> Options, ContractSellConfiguration configuration, OptionType optionType)
        {
            throw new NotImplementedException();
        }
    }
}
