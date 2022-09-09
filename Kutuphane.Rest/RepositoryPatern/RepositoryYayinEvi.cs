using AutoMapper;
using Kutuphane.Rest.Data;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;

namespace Kutuphane.Rest.RepositoryPatern
{
    public class RepositoryYayinEvi : IRepositoryYayinEvi
    {
        readonly MyDBContext _dbContext;
        readonly IMapper _mapper;
        public RepositoryYayinEvi(MyDBContext myDBContext,IMapper mapper)
        {
            _dbContext = myDBContext;
            _mapper = mapper;
        }

        public bool CreateYayinEvi(YayinEvi yayin)
        {
            _dbContext.Add(yayin);
            return Save();
        }

        public bool DeleteYayinEvi(YayinEvi durum)
        {
            _dbContext.Remove(durum);
            return Save();
        }

        public YayinEvi GetYayinEvi(int id)
        {
            return _dbContext.YayınEvis.Where(x => x.ID == id).FirstOrDefault();
        }

        public ICollection<YayinEvi> GetYayinEvis()
        {
            return _dbContext.YayınEvis.OrderBy(x => x.ID).ToList();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateYayinEvi(YayinEvi durum)
        {
            _dbContext.Update(durum);
            return Save();
        }
    }
}
