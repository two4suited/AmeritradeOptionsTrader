namespace External.Ameritrade.API.Models.Options
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class OptionChain
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("underlying")]
        public object Underlying { get; set; }

        [JsonPropertyName("strategy")]
        public string Strategy { get; set; }

        [JsonPropertyName("interval")]
        public long Interval { get; set; }

        [JsonPropertyName("isDelayed")]
        public bool IsDelayed { get; set; }

        [JsonPropertyName("isIndex")]
        public bool IsIndex { get; set; }

        [JsonPropertyName("interestRate")]
        public double InterestRate { get; set; }

        [JsonPropertyName("underlyingPrice")]
        public double UnderlyingPrice { get; set; }

        [JsonPropertyName("volatility")]
        public long Volatility { get; set; }

        [JsonPropertyName("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonPropertyName("numberOfContracts")]
        public long NumberOfContracts { get; set; }

        [JsonPropertyName("putExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> PutExpDateMap { get; set; }

        [JsonPropertyName("callExpDateMap")]
        public Dictionary<string, Dictionary<string, Option[]>> CallExpDateMap { get; set; }
    }

    public partial class Option
    {
        [JsonPropertyName("putCall")]
        public PutCall PutCall { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exchangeName")]
        public ExchangeName ExchangeName { get; set; }

        [JsonPropertyName("bid")]
        public double Bid { get; set; }

        [JsonPropertyName("ask")]
        public double Ask { get; set; }

        [JsonPropertyName("last")]
        public double Last { get; set; }

        [JsonPropertyName("mark")]
        public double Mark { get; set; }

        [JsonPropertyName("bidSize")]
        public long BidSize { get; set; }

        [JsonPropertyName("askSize")]
        public long AskSize { get; set; }

        [JsonPropertyName("bidAskSize")]
        public string BidAskSize { get; set; }

        [JsonPropertyName("lastSize")]
        public long LastSize { get; set; }

        [JsonPropertyName("highPrice")]
        public double HighPrice { get; set; }

        [JsonPropertyName("lowPrice")]
        public double LowPrice { get; set; }

        [JsonPropertyName("openPrice")]
        public long OpenPrice { get; set; }

        [JsonPropertyName("closePrice")]
        public double ClosePrice { get; set; }

        [JsonPropertyName("totalVolume")]
        public long TotalVolume { get; set; }

        [JsonPropertyName("tradeDate")]
        public object TradeDate { get; set; }

        [JsonPropertyName("tradeTimeInLong")]
        public long TradeTimeInLong { get; set; }

        [JsonPropertyName("quoteTimeInLong")]
        public long QuoteTimeInLong { get; set; }

        [JsonPropertyName("netChange")]
        public long NetChange { get; set; }

        [JsonPropertyName("volatility")]
        public long Volatility { get; set; }

        [JsonPropertyName("delta")]
        public long Delta { get; set; }

        [JsonPropertyName("gamma")]
        public long Gamma { get; set; }

        [JsonPropertyName("theta")]
        public long Theta { get; set; }

        [JsonPropertyName("vega")]
        public long Vega { get; set; }

        [JsonPropertyName("rho")]
        public long Rho { get; set; }

        [JsonPropertyName("openInterest")]
        public long OpenInterest { get; set; }

        [JsonPropertyName("timeValue")]
        public double TimeValue { get; set; }

        [JsonPropertyName("theoreticalOptionValue")]
        public long TheoreticalOptionValue { get; set; }

        [JsonPropertyName("theoreticalVolatility")]
        public long TheoreticalVolatility { get; set; }

        [JsonPropertyName("optionDeliverablesList")]
        public object OptionDeliverablesList { get; set; }

        [JsonPropertyName("strikePrice")]
        public long StrikePrice { get; set; }

        [JsonPropertyName("expirationDate")]
        public long ExpirationDate { get; set; }

        [JsonPropertyName("daysToExpiration")]
        public long DaysToExpiration { get; set; }

        [JsonPropertyName("expirationType")]
        public ExpirationType ExpirationType { get; set; }

        [JsonPropertyName("lastTradingDay")]
        public long LastTradingDay { get; set; }

        [JsonPropertyName("multiplier")]
        public long Multiplier { get; set; }

        [JsonPropertyName("settlementType")]
        public SettlementType SettlementType { get; set; }

        [JsonPropertyName("deliverableNote")]
        public string DeliverableNote { get; set; }

        [JsonPropertyName("isIndexOption")]
        public object IsIndexOption { get; set; }

        [JsonPropertyName("percentChange")]
        public long PercentChange { get; set; }

        [JsonPropertyName("markChange")]
        public double MarkChange { get; set; }

        [JsonPropertyName("markPercentChange")]
        public double MarkPercentChange { get; set; }

        [JsonPropertyName("nonStandard")]
        public bool NonStandard { get; set; }

        [JsonPropertyName("inTheMoney")]
        public bool InTheMoney { get; set; }

        [JsonPropertyName("mini")]
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

    internal class ExchangeNameConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExchangeName) || t == typeof(ExchangeName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "OPR")
            {
                return ExchangeName.Opr;
            }
            throw new Exception("Cannot unmarshal type ExchangeName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, Newtonsoft.Json.JsonSerializer serializer)
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

    internal class ExpirationTypeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ExpirationType) || t == typeof(ExpirationType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer, object untypedValue, Newtonsoft.Json.JsonSerializer serializer)
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

    internal class PutCallConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PutCall) || t == typeof(PutCall?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
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

        public override void WriteJson(JsonWriter writer, object untypedValue, Newtonsoft.Json.JsonSerializer serializer)
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

    internal class SettlementTypeConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SettlementType) || t == typeof(SettlementType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == " ")
            {
                return SettlementType.Empty;
            }
            throw new Exception("Cannot unmarshal type SettlementType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, Newtonsoft.Json.JsonSerializer serializer)
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
