namespace ScrTableGPT.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LmResponse
    {
        [JsonProperty("Days")]
        public List<Day> Days { get; set; }
    }

    public partial class Day
    {
        [JsonProperty("Weekday")]
        public short Weekday { get; set; }

        [JsonProperty("Items")]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("StartTime")]
        public DateTimeOffset StartTime { get; set; }

        [JsonProperty("EndTime")]
        public DateTimeOffset EndTime { get; set; }
    }

    public partial class LmResponse
    {
        public static LmResponse FromJson(string json) => JsonConvert.DeserializeObject<LmResponse>(json, ScrTableGPT.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this LmResponse self) => JsonConvert.SerializeObject(self, ScrTableGPT.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}