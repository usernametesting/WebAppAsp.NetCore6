namespace MyWebAppPracting.Models.ModelsMyFirstCodeDatabase
{
    public class Course
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseAndStudent> ?CourseAndStudents { get; set; }
    }
}
