using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class CoursesAndstudent
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual Studentss Student { get; set; } = null!;
    }
}
