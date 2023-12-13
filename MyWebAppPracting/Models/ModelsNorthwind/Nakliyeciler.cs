using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class Nakliyeciler
    {
        public Nakliyeciler()
        {
            Satislars = new HashSet<Satislar>();
        }

        public int NakliyeciId { get; set; }
        public string SirketAdi { get; set; } = null!;
        public string? Telefon { get; set; }

        public virtual ICollection<Satislar> Satislars { get; set; }
    }
}
