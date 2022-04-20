
namespace TestProjectWeb.Data.DbModels
{
    public class Quiz : BaseModel
    {
        public string Title { get; set; }

        public virtual List<Question> Questions{ get; set; }
        public virtual User Creater { get; set; }
    }
}
