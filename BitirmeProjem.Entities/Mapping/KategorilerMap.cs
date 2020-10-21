using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class KategorilerMap : EntityTypeConfiguration<Kategoriler>
    {
        public KategorilerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            
            this.Property(t => t.SeoUrl)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Kategoriler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.UstID).HasColumnName("UstID");
            this.Property(t => t.SeoUrl).HasColumnName("SeoUrl");

            // Relationships
            this.HasOptional(t => t.Kategoriler2)
                .WithMany(t => t.Kategoriler1)
                .HasForeignKey(d => d.UstID);

        }
    }
}
