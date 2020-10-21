using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjem.Entities.Concrete
{
    public class Favoriler:IEntity
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public int UrunID { get; set; }
        public virtual Urunler Urunler { get; set; }
        public virtual Uyeler Uyeler { get; set; }

    }
}
