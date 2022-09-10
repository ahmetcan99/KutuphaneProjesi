using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;


namespace Kutuphane.Rest.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //ilgili modeller ve dto ları arasonda bağlantı sağlandı
            //post işlemi için ayrıca dto->model ilişkisi mapi oluşturuldu.

            CreateMap<Kitap, KitapDto>();
            CreateMap<UyeBilgileri, UyeBilgileriDto>();
            CreateMap<YayinEvi, YayinEviDto>();
            CreateMap<Durum, DurumDto>();
            CreateMap<DurumDto, Durum>();
            CreateMap<YayinEviDto,YayinEvi>();
            CreateMap<UyeBilgileriDto,UyeBilgileri>();
            CreateMap<KitapDto,Kitap>();
            CreateMap<KitapHareket, KitapHareketDto>();
            CreateMap<KitapHareketDto, KitapHareket>();
           

        }

    }

}