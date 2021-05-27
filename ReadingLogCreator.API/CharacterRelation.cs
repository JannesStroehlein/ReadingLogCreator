using System;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CharacterRelation
    {
        [JsonProperty("peerGuid")]
        public Guid PeerGuid { get; set; }
        [JsonProperty("relationType")]
        public string RelationType { get; set; }
        [JsonProperty("terminated")]
        public bool Terminated { get; set; }
    }
}
