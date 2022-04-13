using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class CreateQuizViewModel
    {
        public string Word { get; set; }
        public string Translate { get; set; }
    }
}
