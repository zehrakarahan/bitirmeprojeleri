namespace BitirmeProjem.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urunler")]
    public partial class Urunler: Core.Entities.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler()
        {
            Yorumlar = new HashSet<Yorumlar>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Adi { get; set; }

        public int KategoriID { get; set; }

        public double Fiyat { get; set; }

        public int Stok { get; set; }

        public int? Goruntulenme { get; set; }

        public short? Yildiz { get; set; }

        [StringLength(250)]
        public string KapakResmi { get; set; }

        [Column(TypeName = "text")]
        public string Detay { get; set; }

        [StringLength(250)]
        public string SeoUrl { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorumlar> Yorumlar { get; set; }
    }
}
