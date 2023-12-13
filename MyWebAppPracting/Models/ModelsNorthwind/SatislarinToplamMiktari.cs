using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class SatislarinToplamMiktari
    {
        public decimal? SaleAmount { get; set; }
        public int SatisId { get; set; }
        public string SirketAdi { get; set; } = null!;
        public DateTime? SevkTarihi { get; set; }
    }
}
