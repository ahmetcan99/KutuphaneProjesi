using Kutuphane.Rest.Models;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryUye
    {
        ICollection<UyeBilgileri> GetUyeBilgileris();
        UyeBilgileri GetUyeBilgileri(int id);
        bool DeleteUyeBilgileri(UyeBilgileri uyeBilgileri);
        bool CreateUyeBilgileri(UyeBilgileri uyeBilgileri);
        bool UpdateUyeBilgileri(UyeBilgileri uyeBilgileri);
        bool Save();

    }
}
