using BitirmeProjem.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BitirmeProjem.Entities.Mapping
{
    public class IlcelerMap : EntityTypeConfiguration<Ilceler>
    {
        public IlcelerMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Ilceler");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.SehirID).HasColumnName("SehirID");

            // Relationships
            this.HasRequired(t => t.Sehirler)
                .WithOptional(t => t.Ilceler);

        }
    }
}
