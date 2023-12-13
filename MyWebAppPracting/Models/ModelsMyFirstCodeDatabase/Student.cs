using System.Reflection.Metadata.Ecma335;

namespace MyWebAppPracting.Models.ModelsMyFirstCodeDatabase
{
    public class Student
    {
        public  int Id { get; set; }
        public  string Name { get; set; }
        public  string Surname { get; set; }
        public int GenderId { get; set; }
        public Gender Gen { get; set; }
        public ICollection<CourseAndStudent>? CourseAndStudents { get; set; }
    }
}
