
namespace TestProjectWeb.Data.DbModels
{
    public class Variant : BaseModel
    {
        public string Value { get; set; }

        public virtual Question Question { get; set; }
    }
}
