namespace TestProjectWeb.Data.DbModels
{
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Translation { get; set; }

        public virtual User Creater { get; set; }
    }
}
