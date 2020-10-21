using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Urunler : IEntity
    {
        public Urunler()
        {
            this.Yorumlars = new List<Yorumlar>();
            this.Favorilers = new List<Favoriler>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public int KategoriID { get; set; }
        public double Fiyat { get; set; }
        public int Stok { get; set; }
        public int? Goruntulenme { get; set; }
        public short? Yildiz { get; set; }
        public string KapakResmi { get; set; }
        public string Detay { get; set; }
        public string SeoUrl { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
        public virtual ICollection<Favoriler> Favorilers { get; set; }


    }
}
