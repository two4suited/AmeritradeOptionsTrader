using System.IO;
using System.Text.Json;
using External.Ameritrade.API.Models.Options;
using Shouldly;
using Xunit;

namespace External.Ameritrade.API.Tests
{
    public class OptionChainTests
    {
        private readonly OptionChain _optionChain;
        private readonly string _jsonString;
        public OptionChainTests()
        {
            _jsonString = File.ReadAllText(@"files/optionchain.json");                        
            _optionChain = OptionChain.FromJson(_jsonString);
        }

        [Fact]
        public void FileHadData() => _jsonString.ShouldNotBeNullOrEmpty();

        [Fact]
        public void ValidMaps_Symbol() => _optionChain.Symbol.ShouldBe("AAPL");

        [Fact]
        public void ValidMaps_Option_Puts_ShouldNotBeNull()
        {
            var puts = _optionChain.Puts;
            puts.ShouldNotBeNull();
        }

        [Fact]
        public void ValidMaps_Option_Calls_ShouldNotBeNull()
        {
            var calls = _optionChain.Calls ;
            calls.ShouldNotBeNull();
        }
    }
}