using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class Studentss
    {
        public Studentss()
        {
            CoursesAndstudents = new HashSet<CoursesAndstudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? GenId { get; set; }
        public int? IsDeleted { get; set; }

        public virtual Gen? Gen { get; set; }
        public virtual ICollection<CoursesAndstudent> ?CoursesAndstudents { get; set; }
    }
}
