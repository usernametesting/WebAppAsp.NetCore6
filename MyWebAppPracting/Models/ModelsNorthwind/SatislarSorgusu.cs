using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class SatislarSorgusu
    {
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
        public string SirketAdi { get; set; } = null!;
        public string? Adres { get; set; }
        public string? Sehir { get; set; }
        public string? Bolge { get; set; }
        public string? PostaKodu { get; set; }
        public string? Ulke { get; set; }
    }
}
