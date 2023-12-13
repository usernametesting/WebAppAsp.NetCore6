using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class Satislar
    {
        public Satislar()
        {
            SatisDetaylaris = new HashSet<SatisDetaylari>();
        }

        public int SatisId { get; set; }
        public string? MusteriId { get; set; }
        public int? PersonelId { get; set; }
        public DateTime? SatisTarihi { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime? SevkTarihi { get; set; }
        public int? ShipVia { get; set; }
        public decimal? NakliyeUcreti { get; set; }
        public string? SevkAdi { get; set; }
        public string? SevkAdresi { get; set; }
        public string? SevkSehri { get; set; }
        public string? SevkBolgesi { get; set; }
        public string? SevkPostaKodu { get; set; }
        public string? SevkUlkesi { get; set; }

        public virtual Musteriler? Musteri { get; set; }
        public virtual Personeller? Personel { get; set; }
        public virtual Nakliyeciler? ShipViaNavigation { get; set; }
        public virtual ICollection<SatisDetaylari> SatisDetaylaris { get; set; }
    }
}
