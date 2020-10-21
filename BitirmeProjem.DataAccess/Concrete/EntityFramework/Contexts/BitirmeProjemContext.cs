using Core.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BitirmeProjem.Entities.Concrete;
using BitirmeProjem.Entities.Mapping;
using PlakalikSon.Entities.Concrete;
using BitirmeProjem.DataAccess.Concrete.EntityFramework;

namespace BitirmeProjem.DataAccess.Concrete.EntityFramework.Contexts
{
    public partial class BitirmeProjemContext : DbContext
    {
        static BitirmeProjemContext()
        {
            Database.SetInitializer<BitirmeProjemContext>(null);
        }

        public BitirmeProjemContext()
            : base("Name=BitirmeProjemContext")
        {
        }

        public DbSet<Ilceler> Ilcelers { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Urunler> Urunlers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UyeAdres> UyeAdres { get; set; }
        public DbSet<Uyeler> Uyelers { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<Kuponlar> Kuponlars { get; set; }
        //public DbSet<Favoriler> Favorilers { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new IlcelerMap());
            modelBuilder.Configurations.Add(new KategorilerMap());
            modelBuilder.Configurations.Add(new SehirlerMap());
            modelBuilder.Configurations.Add(new UrunlerMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UyeAdreMap());
            modelBuilder.Configurations.Add(new UyelerMap());
            modelBuilder.Configurations.Add(new YorumlarMap());
            modelBuilder.Configurations.Add(new KuponlarMap());
            //modelBuilder.Configurations.Add(new FavorilerMap());

        }
    }
}
