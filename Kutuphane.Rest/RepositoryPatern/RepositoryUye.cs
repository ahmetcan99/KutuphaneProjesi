using AutoMapper;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Kutuphane.Rest.Tools;

namespace Kutuphane.Rest.RepositoryPatern
{
    public class RepositoryUye : IRepositoryUye
    {
        readonly MyDBContext _dbContext;
        readonly IMapper _mapper;
        public RepositoryUye(MyDBContext myDBContext,IMapper mapper)
        {
            _dbContext = myDBContext;
           _mapper = mapper;
        }
        public bool CreateUyeBilgileri(UyeBilgileri uyeBilgileri)
        {
            uyeBilgileri.Admin = false;
            uyeBilgileri.IsDeleted = false;
            uyeBilgileri.Sifre = Sifreleme.HashPassword(uyeBilgileri.Sifre);
            _dbContext.Add(uyeBilgileri);
            return Save();
        }

        public bool DeleteUyeBilgileri(UyeBilgileri uyeBilgileri)
        {
            _dbContext.Remove(uyeBilgileri);
            return Save();
        }

        public UyeBilgileri GetUyeBilgileri(int id)
        {
            return _dbContext.UyeBilgileris.Where(u => u.ID == id).FirstOrDefault();
        }

        public ICollection<UyeBilgileri> GetUyeBilgileris()
        {
            return _dbContext.UyeBilgileris.Where(u=>u.IsDeleted==false).ToList();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUyeBilgileri(UyeBilgileri uyeBilgileri)
        {
            _dbContext.Update(uyeBilgileri);
            return Save();
        }
    }
}
