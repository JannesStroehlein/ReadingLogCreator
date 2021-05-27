using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FAQQuestion
    {
        [JsonProperty("guid")]
        public Guid Guid { get; internal set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("answered")]
        public bool Answered { get; set; }
        [JsonProperty("answers")]
        public List<FAQAnswer> Answers { get; set; }
    }
}
