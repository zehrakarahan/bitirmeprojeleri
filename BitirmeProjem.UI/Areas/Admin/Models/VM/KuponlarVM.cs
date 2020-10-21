using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BitirmeProjem.UI.Areas.Admin.Models.VM
{
    public class KuponlarVM:BaseModel
    {
        public KuponlarVM()
        {
            BitisTarihi = DateTime.Now.AddDays(10);
        }
        public int ID { get; set; }
        public string Kodu { get; set; }
        public int Oran { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BitisTarihi { get; set; }
    }
}