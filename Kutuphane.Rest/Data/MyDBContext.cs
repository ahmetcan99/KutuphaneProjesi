using Kutuphane.Rest.Configurations;
using Kutuphane.Rest.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane.Rest.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        public DbSet<Kitap>Kitaps { get; set; } 
        public DbSet<UyeBilgileri> UyeBilgileris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new KitapConfiguration());
            modelBuilder.ApplyConfiguration(new UyeBilgileriConfiguration());

        }
    }
}
