using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class FavorilerMap : EntityTypeConfiguration<Favoriler>
    {
        public FavorilerMap()
        {
            this.HasKey(t => t.ID);
            // Table & Column Mappings
            this.ToTable("Favoriler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.UyeID).HasColumnName("UyeID");
         

            // Relationships
            this.HasRequired(t => t.Urunler)
                .WithMany(t => t.Favorilers)
                .HasForeignKey(d => d.UrunID);
            this.HasRequired(t => t.Uyeler)
                .WithMany(t => t.Favorilers)
                .HasForeignKey(d => d.UyeID);
        }
    }
}
