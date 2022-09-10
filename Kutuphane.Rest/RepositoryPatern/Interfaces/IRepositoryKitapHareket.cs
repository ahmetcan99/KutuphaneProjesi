using Kutuphane.Rest.Models;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryKitapHareket
    {


        ICollection<KitapHareket> GetKitapHareketArşiv();
        ICollection<KitapHareket> GetAllKitapHarekets();
        KitapHareket GetKitapHareketByID(int id);
        bool CreateKitapHareket(KitapHareket kitap);
        bool UpdateKitapHareket(KitapHareket kitap);
      

        bool Save();
    }
}
