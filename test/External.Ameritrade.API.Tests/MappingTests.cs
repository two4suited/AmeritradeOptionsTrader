using System.Collections.Generic;
using AutoFixture.Xunit2;
using External.Ameritrade.API.Mappings;
using External.Ameritrade.API.Models.Options;
using Shouldly;
using Xunit;

namespace External.Ameritrade.API.Tests
{
    public class MappingTests
    {
        public OptionChain _optionChain;
       
        public MappingTests()
        {
            _optionChain = TestHelper.CreateOption();
            
            var put = TestHelper.CreateOption("PUT");

            var puts = new Option[] { put };

            var call = TestHelper.CreateOption("CALL");

            var calls = new Option[] {call};

            _optionChain.Puts.Add("2021-07-09:5",new Dictionary<string, Option[]>(){ {"138.0",puts}});
            _optionChain.Calls.Add("2021-07-09:5",new Dictionary<string, Option[]>(){ {"138.0",calls}});
            
        }

        private Option GetPutOption()
        {
            return _optionChain.Puts["2021-07-09:5"]["138.0"][0];
        }

        [Theory,AutoData]
        public void CheckStock_NotNull(OptionChain optionChain)
        {
            var mapper = new OptionChainToStock(optionChain);

            var stock = mapper.MapToStock();

            stock.ShouldNotBeNull();
        }

        [Theory,AutoData]
        public void CheckStock_Map_Symbol(OptionChain optionChain)
        {
            var mapper = new OptionChainToStock(optionChain);

            var stock = mapper.MapToStock();

            stock.Symbol.ShouldBe(optionChain.Symbol);
        }

        [Theory,AutoData]
        public void CheckStock_Map_Price(OptionChain optionChain)
        {
            var mapper = new OptionChainToStock(optionChain);

            var stock = mapper.MapToStock();

            stock.Price.ShouldBe(optionChain.UnderlyingPrice);
        }

        [Fact]
        public void CheckStock_Map_OptionList()
        {
            var mapper = new OptionChainToStock(_optionChain);

            var stock = mapper.MapToStock();

            stock.Options.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void CheckStock_Map_ID()
        {
            var mapper = new OptionChainToStock(_optionChain);

            var stock = mapper.MapToStock();

            stock.Options[0].Id.ShouldBe(GetPutOption().Symbol);
        }
        [Fact]
        public void CheckStock_Map_PutCall()
        {
            var mapper = new OptionChainToStock(_optionChain);

            var stock = mapper.MapToStock();

            stock.Options[0].PutCall.ToString().ShouldBe(GetPutOption().PutCall);
        }
         [Fact]
        public void CheckStock_Map_Delta()
        {
            var mapper = new OptionChainToStock(_optionChain);

            var stock = mapper.MapToStock();

            stock.Options[0].Delta.ShouldBe(GetPutOption().Delta);
        }
        [Fact]
        public void CheckStock_Map_Vega()
        {
            var mapper = new OptionChainToStock(_optionChain);

            var stock = mapper.MapToStock();

            stock.Options[0].Vega.ShouldBe(GetPutOption().Vega);
        }
    }
}