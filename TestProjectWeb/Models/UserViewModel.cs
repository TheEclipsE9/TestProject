using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LearningLanguage { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}
