using System.ComponentModel.DataAnnotations;

namespace TestProjectWeb.Data.DbModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual List<Word> Words { get; set; }
    }
}
