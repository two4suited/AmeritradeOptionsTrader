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
        public void Should_Return_Put_Close_Price(Option option, ContractCloseConfiguration configuration)
        {
            option.Premium = 1.0M;
            configuration.PercentageOfPremium = .7M;

            var trader = new OptionTrader();
            var closeOption = trader.CloseOptionContract(option, configuration, OptionType.Put);

            closeOption.Premium.ShouldBe(option.Premium * configuration.PercentageOfPremium);

        }
    }
}
