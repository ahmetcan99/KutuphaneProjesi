

using Kutuphane.Rest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kutuphane.Rest.Configurations
{
    public class KitapConfiguration:IEntityTypeConfiguration<Kitap>
    {
        public void Configure(EntityTypeBuilder<Kitap>builder)
        {
            builder.Property(x => x.Adi).IsRequired();
            builder.Property(x => x.Yazari).IsRequired();
            builder.Property(x => x.Türü).IsRequired();
            builder.Property(x => x.BasimTarihi).IsRequired();
            builder.Property(x => x.SayfaSayisi).IsRequired();
            builder.Property(x => x.YayinEvi).IsRequired();
            builder.Property(x => x.Durumu).IsRequired();
            
        }

    }
}
