using System;
using System.Collections.Generic;

namespace MyWebAppPracting.Models
{
    public partial class Kategoriler
    {
        public Kategoriler()
        {
            Urunlers = new HashSet<Urunler>();
        }

        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; } = null!;
        public string? Tanimi { get; set; }
        public byte[]? Resim { get; set; }

        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
