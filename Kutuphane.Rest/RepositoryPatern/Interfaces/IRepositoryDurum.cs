using Kutuphane.Rest.Models;
using System.Diagnostics.Metrics;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryDurum
    {
        ICollection<Durum> GetDurums();
        Durum GetDurum(int id);
        Durum GetDurumByKitap(int kitapId);
        ICollection<Kitap> GetKitapFromADurum(int durumId);
       
        bool CreateDurum(Durum durum);
        bool UpdateDurum(Durum durum);
        bool DeleteDurum(Durum durum);
        bool Save();
    }
}
