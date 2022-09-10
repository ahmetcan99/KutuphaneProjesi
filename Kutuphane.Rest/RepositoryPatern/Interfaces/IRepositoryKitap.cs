using Kutuphane.Rest.Models;
using System.Linq.Expressions;

namespace Kutuphane.Rest.RepositoryPatern.Interfaces
{
    public interface IRepositoryKitap
    {
        ICollection<Kitap> GetBook();
        Kitap GetBookByID(int id);
        //Kitap GetBookByYayınEvi(int yayınEviID);
        //ICollection<YayinEvi> GetBooksByPublisherHouse(int bookId);

        bool CreateKitap(Kitap kitap);
        bool UpdateKitap(Kitap kitap);
        bool DeleteKitap(Kitap kitap);
        bool Save();
        



    }
}
