using System.ComponentModel.DataAnnotations;

namespace TestProjectWeb.Data.DbModels
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
