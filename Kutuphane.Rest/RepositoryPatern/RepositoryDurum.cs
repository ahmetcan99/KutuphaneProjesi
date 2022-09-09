using AutoMapper;
using Kutuphane.Rest.Data;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Kutuphane.Rest.RepositoryPatern
{
    public class RepositoryDurum : IRepositoryDurum
    {
        readonly MyDBContext _dbContext;
        readonly IMapper _mapper;
        public RepositoryDurum(MyDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool CreateDurum(Durum durum)
        {
            _dbContext.Add(durum);
            return Save();
        }

        public bool DeleteDurum(Durum durum)
        {
            _dbContext.Remove(durum);
            return Save();
        }

        //örnek id=1 olan kitabın durumunu getir
        public Durum GetDurumByKitap(int kitapId)
        {
            return _dbContext.Kitaps.Where(k => k.ID == kitapId).Select(d => d.Durum).FirstOrDefault();
            
        }

        public ICollection<Durum> GetDurums()
        {
           return _dbContext.Durums.ToList();
        }

        //örnek durum id=1 olan kitapları getir
        public ICollection<Kitap> GetKitapFromADurum(int durumId)
        {
            return _dbContext.Kitaps.Where(d => d.Durum.ID == durumId).ToList();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDurum(Durum durum)
        {
            _dbContext.Update(durum);
            return Save();
        }
        public Durum GetDurum(int id)
        {
            return _dbContext.Durums.Where(c => c.ID == id).FirstOrDefault();
        }
    }
}
