namespace External.Ameritrade.API.Models.Options
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class OptionChain
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("underlying")]
        public object Underlying { get; set; }

        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        [JsonProperty("interval")]
        public long Interval { get; set; }

        [JsonProperty("isDelayed")]
        public bool IsDelayed { get; set; }

        [JsonProperty("isIndex")]
        public bool IsIndex { get; set; }

        [JsonProperty("interestRate")]
        public double InterestRate { get; set; }

        [JsonProperty("underlyingPrice")]
        public double UnderlyingPrice { get; set; }

        [JsonProperty("volatility")]
        public long Volatility { get; set; }

        [JsonProperty("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonProperty("numberOfContracts")]
        public long NumberOfContracts { get; set; }

        [JsonProperty("putExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> PutExpDateMap { get; set; }

        [JsonProperty("callExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> CallExpDateMap { get; set; }
    }

    public partial class Option
    {
        [JsonProperty("putCall")]
        public PutCall PutCall { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exchangeName")]
        public ExchangeName ExchangeName { get; set; }

        [JsonProperty("bid")]
        public double Bid { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("last")]
        public double Last { get; set; }

        [JsonProperty("mark")]
        public double Mark { get; set; }

        [JsonProperty("bidSize")]
        public long BidSize { get; set; }

        [JsonProperty("askSize")]
        public long AskSize { get; set; }

        [JsonProperty("bidAskSize")]
        public string BidAskSize { get; set; }

        [JsonProperty("lastSize")]
        public long LastSize { get; set; }

        [JsonProperty("highPrice")]
        public double HighPrice { get; set; }

        [JsonProperty("lowPrice")]
        public double LowPrice { get; set; }

        [JsonProperty("openPrice")]
        public long OpenPrice { get; set; }

        [JsonProperty("closePrice")]
        public double ClosePrice { get; set; }

        [JsonProperty("totalVolume")]
        public long TotalVolume { get; set; }

        [JsonProperty("tradeDate")]
        public object TradeDate { get; set; }

        [JsonProperty("tradeTimeInLong")]
        public long TradeTimeInLong { get; set; }

        [JsonProperty("quoteTimeInLong")]
        public long QuoteTimeInLong { get; set; }

        [JsonProperty("netChange")]
        public long NetChange { get; set; }

        [JsonProperty("volatility")]
        public long Volatility { get; set; }

        [JsonProperty("delta")]
        public long Delta { get; set; }

        [JsonProperty("gamma")]
        public long Gamma { get; set; }

        [JsonProperty("theta")]
        public long Theta { get; set; }

        [JsonProperty("vega")]
        public long Vega { get; set; }

        [JsonProperty("rho")]
        public long Rho { get; set; }

        [JsonProperty("openInterest")]
        public long OpenInterest { get; set; }

        [JsonProperty("timeValue")]
        public double TimeValue { get; set; }

        [JsonProperty("theoreticalOptionValue")]
        public long TheoreticalOptionValue { get; set; }

        [JsonProperty("theoreticalVolatility")]
        public long TheoreticalVolatility { get; set; }

        [JsonProperty("optionDeliverablesList")]
        public object OptionDeliverablesList { get; set; }

        [JsonProperty("strikePrice")]
        public long StrikePrice { get; set; }

        [JsonProperty("expirationDate")]
        public long ExpirationDate { get; set; }

        [JsonProperty("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonProperty("expirationType")]
        public ExpirationType ExpirationType { get; set; }

        [JsonProperty("lastTradingDay")]
        public long LastTradingDay { get; set; }

        [JsonProperty("multiplier")]
        public long Multiplier { get; set; }

        [JsonProperty("settlementType")]
        public SettlementType SettlementType { get; set; }

        [JsonProperty("deliverableNote")]
        public string DeliverableNote { get; set; }

        [JsonProperty("isIndexOption")]
        public object IsIndexOption { get; set; }

        [JsonProperty("percentChange")]
        public long PercentChange { get; set; }

        [JsonProperty("markChange")]
        public double MarkChange { get; set; }

        [JsonProperty("markPercentChange")]
        public double MarkPercentChange { get; set; }

        [JsonProperty("nonStandard")]
        public bool NonStandard { get; set; }

        [JsonProperty("inTheMoney")]
        public bool InTheMoney { get; set; }

        [JsonProperty("mini")]
        public bool Mini { get; set; }
    }

    public enum ExchangeName { Opr };

    public enum ExpirationType { R, S };

    public enum PutCall { Call, Put };

    public enum SettlementType { Empty };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ExchangeNameConverter.Singleton,
                ExpirationTypeConverter.Singleton,
                PutCallConverter.Singleton,
                SettlementTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ExchangeNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExchangeName) || t == typeof(ExchangeName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "OPR")
            {
                return ExchangeName.Opr;
            }
            throw new Exception("Cannot unmarshal type ExchangeName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ExchangeName)untypedValue;
            if (value == ExchangeName.Opr)
            {
                serializer.Serialize(writer, "OPR");
                return;
            }
            throw new Exception("Cannot marshal type ExchangeName");
        }

        public static readonly ExchangeNameConverter Singleton = new ExchangeNameConverter();
    }

    internal class ExpirationTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExpirationType) || t == typeof(ExpirationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "R":
                    return ExpirationType.R;
                case "S":
                    return ExpirationType.S;
            }
            throw new Exception("Cannot unmarshal type ExpirationType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ExpirationType)untypedValue;
            switch (value)
            {
                case ExpirationType.R:
                    serializer.Serialize(writer, "R");
                    return;
                case ExpirationType.S:
                    serializer.Serialize(writer, "S");
                    return;
            }
            throw new Exception("Cannot marshal type ExpirationType");
        }

        public static readonly ExpirationTypeConverter Singleton = new ExpirationTypeConverter();
    }

    internal class PutCallConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PutCall) || t == typeof(PutCall?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CALL":
                    return PutCall.Call;
                case "PUT":
                    return PutCall.Put;
            }
            throw new Exception("Cannot unmarshal type PutCall");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PutCall)untypedValue;
            switch (value)
            {
                case PutCall.Call:
                    serializer.Serialize(writer, "CALL");
                    return;
                case PutCall.Put:
                    serializer.Serialize(writer, "PUT");
                    return;
            }
            throw new Exception("Cannot marshal type PutCall");
        }

        public static readonly PutCallConverter Singleton = new PutCallConverter();
    }

    internal class SettlementTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SettlementType) || t == typeof(SettlementType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == " ")
            {
                return SettlementType.Empty;
            }
            throw new Exception("Cannot unmarshal type SettlementType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SettlementType)untypedValue;
            if (value == SettlementType.Empty)
            {
                serializer.Serialize(writer, " ");
                return;
            }
            throw new Exception("Cannot marshal type SettlementType");
        }

        public static readonly SettlementTypeConverter Singleton = new SettlementTypeConverter();
    }
}
