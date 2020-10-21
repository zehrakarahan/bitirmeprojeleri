using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class UrunlerMap : EntityTypeConfiguration<Urunler>
    {
        public UrunlerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.KapakResmi)
                .HasMaxLength(250);

            this.Property(t => t.SeoUrl)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Urunler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");
            this.Property(t => t.Fiyat).HasColumnName("Fiyat");
            this.Property(t => t.Stok).HasColumnName("Stok");
            this.Property(t => t.Goruntulenme).HasColumnName("Goruntulenme");
            this.Property(t => t.Yildiz).HasColumnName("Yildiz");
            this.Property(t => t.KapakResmi).HasColumnName("KapakResmi");
            this.Property(t => t.Detay).HasColumnName("Detay");
            this.Property(t => t.SeoUrl).HasColumnName("SeoUrl");

            // Relationships
            this.HasRequired(t => t.Kategoriler)
                .WithMany(t => t.Urunler)
                .HasForeignKey(d => d.KategoriID);

        }
    }
}
