using System.ComponentModel.DataAnnotations;
using TestProjectWeb.Data.Enums;

namespace TestProjectWeb.Data.DbModels
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual Question Question { get; set; }
    }
}
