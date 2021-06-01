using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public DateTime ReleaseDate { get; set; }
        [JsonProperty("chapters")]
        public ObservableCollection<Chapter> Chapters { get; internal set; }
        [JsonProperty("characters")]
        public ObservableCharacterCollection Characters { get; internal set; }

        public ReadingLog()
        {
            this.Characters = new ObservableCharacterCollection();
            this.Chapters = new ObservableCollection<Chapter>();
        }
        public string Serialize() => JsonConvert.SerializeObject(this);
        public static ReadingLog Deserialize(string json) => JsonConvert.DeserializeObject<ReadingLog>(json);
    }
}
