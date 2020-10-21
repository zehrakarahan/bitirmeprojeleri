using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class UyeAdreMap : EntityTypeConfiguration<UyeAdres>
    {
        public UyeAdreMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Baslik)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Adres)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UyeAdres");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UyeID).HasColumnName("UyeID");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.SehirID).HasColumnName("SehirID");
            this.Property(t => t.IlceID).HasColumnName("IlceID");
            this.Property(t => t.Adres).HasColumnName("Adres");

            // Relationships
            this.HasRequired(t => t.Ilceler)
                .WithMany(t => t.UyeAdres)
                .HasForeignKey(d => d.IlceID);
            this.HasRequired(t => t.Sehirler)
                .WithMany(t => t.UyeAdres)
                .HasForeignKey(d => d.SehirID);

        }
    }
}
