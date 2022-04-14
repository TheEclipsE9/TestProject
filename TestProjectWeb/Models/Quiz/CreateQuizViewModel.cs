using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class CreateQuizViewModel
    {
        public string Title { get; set; }
        public int QuestionsQuantity { get; set; }
    }
}
