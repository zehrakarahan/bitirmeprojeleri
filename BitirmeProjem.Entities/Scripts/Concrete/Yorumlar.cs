using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Yorumlar : IEntity
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public int UyeID { get; set; }
        public string Yorum { get; set; }
        public short Puan { get; set; }
        public bool Onay { get; set; }
        public virtual Urunler Urunler { get; set; }
        public virtual Uyeler Uyeler { get; set; }
    }
}
