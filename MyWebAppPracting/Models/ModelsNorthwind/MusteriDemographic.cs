using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class MusteriDemographic
    {
        public MusteriDemographic()
        {
            Musteris = new HashSet<Musteriler>();
        }

        public string MusteriTypeId { get; set; } = null!;
        public string? MusteriDesc { get; set; }

        public virtual ICollection<Musteriler> Musteris { get; set; }
    }
}
