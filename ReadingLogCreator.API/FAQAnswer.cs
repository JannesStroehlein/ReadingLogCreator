using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class FAQAnswer
    {
        [JsonProperty("answer")]
        public string Answer { get; set; }
    }
}
