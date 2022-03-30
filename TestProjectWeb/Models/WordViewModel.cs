using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Translation { get; set; }
        public string Category { get; set; }
        public PartsOfSpeech PartOfSpeech { get; set; }
    }
}
