using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string LearningLanguage { get; set; }
        [Required]
        public LanguageLevel LanguageLevel { get; set; }

        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
