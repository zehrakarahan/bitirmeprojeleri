using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BitirmeProjem.Entities.Concrete;

namespace BitirmeProjem.UI.Areas.Admin.Models.VM
{
    public class YorumlarVM:BaseModel
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