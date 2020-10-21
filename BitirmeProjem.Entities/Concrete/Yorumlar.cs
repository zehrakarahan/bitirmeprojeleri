namespace BitirmeProjem.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorumlar")]
    public partial class Yorumlar: Core.Entities.IEntity
    {
        public int ID { get; set; }

        public int UrunID { get; set; }

        public int UyeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Yorum { get; set; }

        public short Puan { get; set; }

        public bool Onay { get; set; }

        public virtual Urunler Urunler { get; set; }

        public virtual Uyeler Uyeler { get; set; }
    }
}
