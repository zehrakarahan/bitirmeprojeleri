namespace BitirmeProjem.Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilceler")]
    public partial class Ilceler: Core.Entities.IEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilceler()
        {
            UyeAdres = new HashSet<UyeAdres>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Adi { get; set; }

        public short SehirID { get; set; }

        public virtual Sehirler Sehirler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UyeAdres> UyeAdres { get; set; }
    }
}
