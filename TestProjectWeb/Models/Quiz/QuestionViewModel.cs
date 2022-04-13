using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Models
{
    public class QuestionViewModel
    {
        public string Ask { get; set; }
        public string Answer { get; set; }

        public List<VariantViewModel> VariantViewModels { get; set; }
    }
}
