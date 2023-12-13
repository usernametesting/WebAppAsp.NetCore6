using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class Faturalar
    {
        public string? SevkAdi { get; set; }
        public string? SevkAdresi { get; set; }
        public string? SevkSehri { get; set; }
        public string? SevkBolgesi { get; set; }
        public string? SevkPostaKodu { get; set; }
        public string? SevkUlkesi { get; set; }
        public string? MusteriId { get; set; }
        public string MusteriName { get; set; } = null!;
        public string? Adres { get; set; }
        public string? Sehir { get; set; }
        public string? Bolge { get; set; }
        public string? PostaKodu { get; set; }
        public string? Ulke { get; set; }
        public string PersonelSatislari { get; set; } = null!;
        public int SatisId { get; set; }
        public DateTime? SatisTarihi { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public DateTime? SevkTarihi { get; set; }
        public string NakliyeciName { get; set; } = null!;
        public int UrunId { get; set; }
        public string UrunAdi { get; set; } = null!;
        public decimal BirimFiyati { get; set; }
        public short Miktar { get; set; }
        public float İndirim { get; set; }
        public decimal? ExtendedPrice { get; set; }
        public decimal? NakliyeUcreti { get; set; }
    }
}
