using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class Gen
    {
        public Gen()
        {
            Studentsses = new HashSet<Studentss>();
        }

        public int Id { get; set; }
        public string? Kind { get; set; }

        public virtual ICollection<Studentss> Studentsses { get; set; }
    }
}
