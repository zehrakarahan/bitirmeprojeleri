using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Sehirler : IEntity
    {
        public Sehirler()
        {
            this.UyeAdres = new List<UyeAdre>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public virtual Ilceler Ilceler { get; set; }
        public virtual ICollection<UyeAdre> UyeAdres { get; set; }
    }
}
