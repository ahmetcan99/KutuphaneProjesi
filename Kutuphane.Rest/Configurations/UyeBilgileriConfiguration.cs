using Kutuphane.Rest.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kutuphane.Rest.Configurations
{
    public class UyeBilgileriConfiguration:IEntityTypeConfiguration<UyeBilgileri>
    {
       
            public void Configure(EntityTypeBuilder<UyeBilgileri>builder)
            {
            builder.Property(x => x.Ad).IsRequired();
            builder.Property(x=>x.Soyad).IsRequired();
            builder.Property(x => x.KullaniciAdi).IsRequired();
            builder.Property(x => x.Sifre).IsRequired();
            
            builder.Property(x => x.KayitTarihi).IsRequired();
            builder.Property(x => x.UyeDurumu).IsRequired();
            builder.Property(x => x.Admin).IsRequired();

            }

        }
    
}
