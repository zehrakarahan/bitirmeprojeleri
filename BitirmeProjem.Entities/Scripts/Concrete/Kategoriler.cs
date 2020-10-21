using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Kategoriler : IEntity
    {
        public Kategoriler()
        {
            this.Kategoriler1 = new List<Kategoriler>();
            this.Urunlers = new List<Urunler>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public int? UstID { get; set; }
        public string SeoUrl { get; set; }
        public virtual ICollection<Kategoriler> Kategoriler1 { get; set; }
        public virtual Kategoriler Kategoriler2 { get; set; }
        public virtual ICollection<Urunler> Urunlers { get; set; }
    }
}
