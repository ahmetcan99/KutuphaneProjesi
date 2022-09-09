using Kutuphane.Rest.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kutuphane.Rest.Configurations
{
    public class KitapHareketleriConfiguration : IEntityTypeConfiguration<KitapHareket>
    {
      
            public void Configure(EntityTypeBuilder<KitapHareket> builder)
            {
            builder.Ignore(x => x.ID);
            builder.HasKey(x => new { x.UyeBilgileriID, x.KitapID });
            builder.HasOne(kh => kh.Kitap).WithMany(k =>k.KitapHarekets).HasForeignKey(kh => kh.KitapID);
            builder.HasOne(kh => kh.UyeBilgileri).WithMany(u => u.KitapHarekets).HasForeignKey(kh => kh.UyeBilgileriID);


        }

        
    }
}
