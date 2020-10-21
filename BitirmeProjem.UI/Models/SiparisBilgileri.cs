using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeProjem.UI.Models
{
    public class SiparisBilgileri
    {
        public int UyeId { get; set; }
        public string Baslik { get; set; }
        public int SehirId { get; set; }
        public int IlceId { get; set; }
        public string Adres { get; set; }
    }
}