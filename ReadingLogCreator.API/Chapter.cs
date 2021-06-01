using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Chapter
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("index")]
        public int Index { get; internal set; }
        [JsonProperty("startPage")]
        public int StartPage { get; set; }
        [JsonProperty("endPage")]
        public int EndPage { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("relations")]
        public ObservableCollection<CharacterRelation> Relations { get; internal set; }
        [JsonProperty("questions")]
        public ObservableCollection<FAQQuestion> Questions { get; internal set; }
        [JsonProperty("extraInformation")]
        public Dictionary<string, string> ExtraInformation { get; internal set; }

        public Chapter()
        {
            this.Relations = new ObservableCollection<CharacterRelation>();
            this.Questions = new ObservableCollection<FAQQuestion>();
            this.ExtraInformation = new Dictionary<string, string>();
        }
    }
}
