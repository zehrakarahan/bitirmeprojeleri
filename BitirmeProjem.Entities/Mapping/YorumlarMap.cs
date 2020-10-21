using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class YorumlarMap : EntityTypeConfiguration<Yorumlar>
    {
        public YorumlarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Yorum)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Yorumlar");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.UyeID).HasColumnName("UyeID");
            this.Property(t => t.Yorum).HasColumnName("Yorum");
            this.Property(t => t.Puan).HasColumnName("Puan");
            this.Property(t => t.Onay).HasColumnName("Onay");

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Yorumlar)
                .HasForeignKey(d => d.UrunID);
            this.HasRequired(t => t.Uyeler)
                .WithMany(t => t.Yorumlar)
                .HasForeignKey(d => d.UyeID);

        }
    }
}
