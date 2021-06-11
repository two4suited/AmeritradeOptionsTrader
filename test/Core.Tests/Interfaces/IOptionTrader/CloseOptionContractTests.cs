using AutoFixture.Xunit2;
using Core.Models;
using Core.Services;
using Xunit;
using Shouldly;

namespace Core.Tests.Interfaces.IOptionTrader
{
    public class CloseOptionContractTests
    {
        public CloseOptionContractTests()
        {
            
        }
        [Theory, AutoData]
        public void Should_Return_Put_Close_Price(Stock stock, ContractCloseConfiguration configuration)
        {
            stock.Options[0].Premium=1.0;
            
            configuration.PercentageOfPremium = .7;

            var trader = new OptionTrader();
            var closeOption = trader.CloseOptionContract(stock, configuration, OptionType.Put);

            closeOption.StrikePrice.ShouldBe(stock.Options[0].Premium * configuration.PercentageOfPremium);

        }
    }
}
