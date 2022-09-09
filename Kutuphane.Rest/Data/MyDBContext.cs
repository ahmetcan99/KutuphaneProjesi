using Kutuphane.Rest.Configurations;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;

namespace Kutuphane.Rest.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }
        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<UyeBilgileri> UyeBilgileris { get; set; }
        public DbSet<Durum> Durums { get; set; }
        public DbSet<KitapHareket> KitapHarekets { get; set; }
        public DbSet<YayinEvi> YayınEvis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KitapConfiguration());
            modelBuilder.ApplyConfiguration(new UyeBilgileriConfiguration());
            modelBuilder.ApplyConfiguration(new KitapConfiguration());
            modelBuilder.ApplyConfiguration(new YayinEviConfiguration());
            

        }
    }
}
