using Core.Entities;
using System;
using System.Collections.Generic;

namespace BitirmeProjem.Entities.Concrete
{
    public partial class Kuponlar : IEntity
    {
        public int ID { get; set; }
        public string Kodu { get; set; }
        public int Oran { get; set; }
        public DateTime BitisTarihi { get; set; }
    }
}
