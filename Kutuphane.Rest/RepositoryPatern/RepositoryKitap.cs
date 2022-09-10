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

        public bool CreateKitap(Kitap kitap)
        {
            kitap.IsDeleted = false;
            _myDBContext.Add(kitap);
            return Save();
        }

        public bool DeleteKitap(Kitap kitap)
        {
            kitap.IsDeleted=true;
           _myDBContext.Update(kitap);
            return Save();
        }

        public Kitap GetBookByID(int id)
        {
            return _myDBContext.Kitaps.Where(x => x.ID == id).FirstOrDefault();
        }

        public ICollection<Kitap> GetBook()
        {
            return _myDBContext.Kitaps.Where(x=>x.IsDeleted==false).ToList();
        }

        public bool Save()
        {
           var saved= _myDBContext.SaveChanges();
            return saved >0 ? true : false;
        }

        public bool UpdateKitap(Kitap kitap)
        {
            _myDBContext.Update(kitap);
            return Save();
        }
    }
}
