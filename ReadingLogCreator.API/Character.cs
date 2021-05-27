using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ReadingLogCreator.API
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Character
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("guid")]
        public Guid Guid { get; internal set; }
        [JsonProperty("isMainCharacter"), DefaultValue(false)]
        public bool IsMainCharacter { get; set; }
        [JsonProperty("relations")]
        public List<CharacterRelation> Relations { get; internal set; }
        [JsonProperty("extraInformation")]
        public Dictionary<string, string> ExtraInformation { get; internal set; }

        public Character(string Name)
        {
            this.Name = Name;
            this.Guid = Guid.NewGuid();
        }
    }
}
