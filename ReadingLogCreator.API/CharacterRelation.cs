using System;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterRelation
    {
        [JsonProperty("suspectGuid")]
        public Guid Suspect { get; set; }
        [JsonProperty("targetGuid")]
        public Guid Target { get; set; }
        [JsonProperty("relationType")]
        public string RelationType { get; set; }
        [JsonProperty("terminated")]
        public bool Terminated { get; set; }
    }
}
