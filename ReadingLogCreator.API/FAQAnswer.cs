using Newtonsoft.Json;
using System;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FAQAnswer
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }
        [JsonProperty("guid")]
        public Guid Guid { get; internal set; }
        [JsonProperty("chapterGuid")]
        public Guid ChapterGuid { get; internal set; }
    }
}
