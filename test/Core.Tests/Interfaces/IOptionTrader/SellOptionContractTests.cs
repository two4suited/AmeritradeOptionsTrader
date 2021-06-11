using AutoFixture.Xunit2;
using Core.Models;
using Core.Services;
using Xunit;

namespace Core.Tests.Interfaces.IOptionTrader
{
    public class SellOptionContractTests
    {
        [Theory,AutoData]
        public void Should_Pick_Right_Option_Based_On_Configuration(Stock stock,ContractSellConfiguration configuration)
        {
            configuration.LessThanDelta=-.3;
            configuration.GreaterThanPercentageOfPrice=.01;
            stock.Price=10;

            var optionTrader = new OptionTrader();
            var transaction = optionTrader.SellOptionContract(stock,configuration,OptionType.Put)

            


        }
    }
}