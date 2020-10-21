using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class UyeAdre : IEntity
    {
        public int ID { get; set; }
        public int UyeID { get; set; }
        public string Baslik { get; set; }
        public int SehirID { get; set; }
        public int IlceID { get; set; }
        public string Adres { get; set; }
        public virtual Ilceler Ilceler { get; set; }
        public virtual Sehirler Sehirler { get; set; }
    }
}
