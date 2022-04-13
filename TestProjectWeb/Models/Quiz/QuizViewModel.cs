using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class QuizViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<QuestionViewModel> QuestionViewModels { get; set; }
    }
}
