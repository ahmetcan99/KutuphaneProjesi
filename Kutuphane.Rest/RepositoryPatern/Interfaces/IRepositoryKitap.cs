using Kutuphane.Rest.Models;
using System.Linq.Expressions;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryKitap
    {
        ICollection<Kitap> GetBooks();
        Kitap GetBookByID(int id);
        //Kitap GetBookByYayınEvi(int yayınEviID);
        //ICollection<YayinEvi> GetBooksByPublisherHouse(int bookId);

        bool CreateKitap(Kitap kitap);
        bool UpdateKitap(int hareketId, int yayinId,Kitap kitap);
        bool DeleteKitap(Kitap kitap);
        



    }
}
