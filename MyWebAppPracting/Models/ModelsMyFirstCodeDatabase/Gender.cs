namespace MyWebAppPracting.Models.ModelsMyFirstCodeDatabase
{
    public class Gender
    {
        public int Id { get; set; }
        public string Gen { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
