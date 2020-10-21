using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeProjem.UI.Models
{
    public class SepetUrun
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunResim { get; set; }
        public string UrunUrl { get; set; }
        public int Adet { get; set; }
        public double Fiyat { get; set; }
    }
}