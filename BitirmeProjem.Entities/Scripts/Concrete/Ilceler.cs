using Core.Entities;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Ilceler : IEntity
    {
        public Ilceler()
        {
            this.UyeAdres = new List<UyeAdre>();
        }

        public int ID { get; set; }
        public string Adi { get; set; }
        public short SehirID { get; set; }
        public virtual Sehirler Sehirler { get; set; }
        public virtual ICollection<UyeAdre> UyeAdres { get; set; }
    }
}
