using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Data.DbModels
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Translation { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public PartsOfSpeech PartOfSpeech { get; set; }

        public virtual User Creater { get; set; }
    }
}
