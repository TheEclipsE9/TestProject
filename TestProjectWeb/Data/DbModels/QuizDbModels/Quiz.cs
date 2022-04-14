using System.ComponentModel.DataAnnotations;

namespace TestProjectWeb.Data.DbModels
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual List<Question> Questions{ get; set; }
        public virtual User Creater { get; set; }
    }
}
