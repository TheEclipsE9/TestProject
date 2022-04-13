using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Data.DbModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Ask { get; set; }
        public string Answer { get; set; }

        public virtual List<Variant> Variants { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
