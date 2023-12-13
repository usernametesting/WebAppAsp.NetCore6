using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class Bolge
    {
        public Bolge()
        {
            Bolgelers = new HashSet<Bolgeler>();
        }

        public int BolgeId { get; set; }
        public string BolgeTanimi { get; set; } = null!;

        public virtual ICollection<Bolgeler> Bolgelers { get; set; }
    }
}
