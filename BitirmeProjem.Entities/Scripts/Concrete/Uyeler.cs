using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Uyeler : IEntity
    {
        public Uyeler()
        {
            this.Yorumlars = new List<Yorumlar>();
            this.Favorilers = new List<Favoriler>();

        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
        public virtual ICollection<Favoriler> Favorilers { get; set; }

    }
}
