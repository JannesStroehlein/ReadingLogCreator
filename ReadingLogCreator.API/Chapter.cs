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
        [JsonProperty("characters")]
        public ObservableCollection<Character> Characters { get; internal set; }
        [JsonProperty("questions")]
        public ObservableCollection<FAQQuestion> Questions { get; internal set; }
    }
}
