namespace BitirmeProjem.Entities.Concrete
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UyeAdres: IEntity
    {
        public int ID { get; set; }

        public int UyeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        public int SehirID { get; set; }

        public int IlceID { get; set; }

        [Required]
        [StringLength(50)]
        public string Adres { get; set; }

        public virtual Ilceler Ilceler { get; set; }

        public virtual Sehirler Sehirler { get; set; }
    }
}
