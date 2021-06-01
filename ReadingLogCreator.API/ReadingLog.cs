using System;
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
        [JsonProperty("FAQ")]
        public ObservableCollection<FAQQuestion> FAQQuestions { get; internal set; }

        public ReadingLog()
        {
            this.Characters = new ObservableCharacterCollection();
            this.Chapters = new ObservableCollection<Chapter>();
            this.FAQQuestions = new ObservableCollection<FAQQuestion>();
        }
        public void NewChapter(string Title, int StartPage, int Endpage)
        {
            this.Chapters.Add(new Chapter()
            {
                Title = Title,
                StartPage = StartPage,
                EndPage = Endpage,
                Guid = Guid.NewGuid()
            });
        }
        public void NewCharacter(string Name)
        {
            this.Characters.Add(new Character()
            {
                Name = Name,
                Guid = Guid.NewGuid()
            });
        }
        public string Serialize() => JsonConvert.SerializeObject(this);
        public static ReadingLog Deserialize(string json) => JsonConvert.DeserializeObject<ReadingLog>(json);
    }
}
