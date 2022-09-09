using AutoMapper;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kutuphane.Rest.RepositoryPatern
{
    public class RepositoryKitap : IRepositoryKitap
    { 
       readonly MyDBContext _myDBContext;
        readonly IMapper _mapper;
        public RepositoryKitap(MyDBContext myDBContext,IMapper mapper)
        {
            _myDBContext = myDBContext;
            _mapper = mapper;   
        }

        public bool CreateKitap(int hareketId, int yayinId, Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public bool CreateKitap(Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public bool DeleteKitap(Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public Kitap GetBookByID(int id)
        {
            return _myDBContext.Kitaps.Find(id);
        }

        //public Kitap GetBookByYayınEvi(int yayınEviID)
        //{
        //    return _myDBContext.YayınEvis.Where(y => y.ID == yayınEviID).Select(k => k.Kitap).FirstOrDefault();
        //}

        public ICollection<Kitap> GetBooks()
        {
            return _myDBContext.Kitaps.OrderBy(u => u.ID).ToList();
        }

        //public ICollection<YayinEvi> GetBooksByPublisherHouse(int bookId)
        //{
        //    return _myDBContext.YayınEvis.Where(r => r.Kitap.ID == bookId).ToList();
        //}

        public bool UpdateKitap(int hareketId, int yayinId, Kitap kitap)
        {
            throw new NotImplementedException();
        }
    }
}
