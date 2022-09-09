using Kutuphane.Rest.Models;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryYayinEvi
    {
        //ICollection<YayinEvi> GetirPublisherHouseOfABook(int bookID);
        ICollection<YayinEvi> GetYayinEvis();
        YayinEvi GetYayinEvi(int id);

        bool CreateYayinEvi(YayinEvi durum);
        bool UpdateYayinEvi(YayinEvi durum);
        bool DeleteYayinEvi(YayinEvi durum);
        bool Save();
    }
}
