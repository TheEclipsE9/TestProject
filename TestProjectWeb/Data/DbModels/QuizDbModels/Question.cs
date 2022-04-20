
namespace TestProjectWeb.Data.DbModels
{
    public class Question : BaseModel
    {
        public string Ask { get; set; }
        public string Answer { get; set; }

        public virtual List<Variant> Variants { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
