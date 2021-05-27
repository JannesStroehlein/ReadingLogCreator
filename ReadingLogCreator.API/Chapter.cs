using System.Collections.Generic;
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
        [JsonProperty("characters")]
        public List<Character> Characters { get; internal set; }
        [JsonProperty("questions")]
        public List<FAQQuestion> Questions { get; internal set; }
    }
}
