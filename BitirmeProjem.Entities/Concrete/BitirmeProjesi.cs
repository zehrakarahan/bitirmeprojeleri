namespace BitirmeProjem.Entities.Concrete
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BitirmeProjesi : DbContext
    {
        public BitirmeProjesi()
            : base("name=BitirmeProjesi")
        {
        }

        public virtual DbSet<Ilceler> Ilceler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Kuponlar> Kuponlar { get; set; }
        public virtual DbSet<Sehirler> Sehirler { get; set; }
        public virtual DbSet<Urunler> Urunler { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UyeAdres> UyeAdres { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
        public virtual DbSet<Yorumlar> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ilceler>()
                .HasMany(e => e.UyeAdres)
                .WithRequired(e => e.Ilceler)
                .HasForeignKey(e => e.IlceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategoriler>()
                .HasMany(e => e.Kategoriler1)
                .WithOptional(e => e.Kategoriler2)
                .HasForeignKey(e => e.UstID);

            modelBuilder.Entity<Kategoriler>()
                .HasMany(e => e.Urunler)
                .WithRequired(e => e.Kategoriler)
                .HasForeignKey(e => e.KategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sehirler>()
                .HasOptional(e => e.Ilceler)
                .WithRequired(e => e.Sehirler);

            modelBuilder.Entity<Sehirler>()
                .HasMany(e => e.UyeAdres)
                .WithRequired(e => e.Sehirler)
                .HasForeignKey(e => e.SehirID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.Detay)
                .IsUnicode(false);

            modelBuilder.Entity<Urunler>()
                .HasMany(e => e.Yorumlar)
                .WithRequired(e => e.Urunler)
                .HasForeignKey(e => e.UrunID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uyeler>()
                .HasMany(e => e.Yorumlar)
                .WithRequired(e => e.Uyeler)
                .HasForeignKey(e => e.UyeID)
                .WillCascadeOnDelete(false);
        }
    }
}
