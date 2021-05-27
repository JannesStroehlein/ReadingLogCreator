using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReadingLog
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("releaseDate")]
        public DateTime ReleaseData { get; set; }
        [JsonProperty("chapters")]
        public List<Chapter> Chapters { get; internal set; }

        public void Serialize() => JsonConvert.SerializeObject(this);
        public static ReadingLog Deserialize(string json) => JsonConvert.DeserializeObject<ReadingLog>(json);
    }
}
