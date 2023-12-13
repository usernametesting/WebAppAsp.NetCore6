using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class Course
    {
        public Course()
        {
            CoursesAndstudents = new HashSet<CoursesAndstudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<CoursesAndstudent> CoursesAndstudents { get; set; }
    }
}
