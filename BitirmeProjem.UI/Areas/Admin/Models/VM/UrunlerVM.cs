using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeProjem.UI.Areas.Admin.Models.VM
{
    public class UrunlerVM:BaseModel
    {
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
        public HttpPostedFileBase File { get; set; }
    }
}