using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class KuponlarMap : EntityTypeConfiguration<Kuponlar>
    {
        public KuponlarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            this.Property(t => t.Kodu)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Kuponlar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Kodu).HasColumnName("Kodu");
            this.Property(t => t.Oran).HasColumnName("Oran");
            this.Property(t => t.BitisTarihi).HasColumnName("BitisTarihi");
        }
    }
}
