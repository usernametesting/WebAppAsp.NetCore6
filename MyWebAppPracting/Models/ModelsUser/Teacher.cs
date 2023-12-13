using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models.ModelsUser
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Profession { get; set; } = null!;
    }
}
