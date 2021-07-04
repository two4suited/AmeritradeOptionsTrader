using System.IO;
using System.Text.Json;
using External.Ameritrade.API.Models.Options;
using Shouldly;
using Xunit;

namespace External.Ameritrade.API.Tests
{
    public class OptionChainTests
    {
        [Fact]
        public void LoadFile_ValidMaps()
        {
            string jsonString = File.ReadAllText(@"files/optionchain.json");
            //jsonString.ShouldBeNullOrEmpty();
            OptionChain optionChain = JsonSerializer.Deserialize<OptionChain>(jsonString);

            optionChain.Symbol.ShouldBe("AAPL");
        }
    }
}