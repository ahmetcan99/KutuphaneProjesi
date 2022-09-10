using AutoMapper;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;

namespace Kutuphane.Rest.RepositoryPatern
{
    public class RepositoryKitapHareketi : IRepositoryKitapHareket
    {
        readonly MyDBContext _myDBContext;
        readonly IMapper _mapper;
        public RepositoryKitapHareketi(MyDBContext myDBContext, IMapper mapper)
        {
            _myDBContext = myDBContext;
            _mapper = mapper;
        }
        public bool CreateKitapHareket(KitapHareket kitap)
        {
            _myDBContext.Add(kitap);
            return Save();
        }

        public ICollection<KitapHareket> GetKitapHareketArşiv()
        {
            return _myDBContext.KitapHarekets.Where(u => u.Kitap.IsDeleted == true).ToList();
        }
        public ICollection<KitapHareket> GetAllKitapHarekets()
        {
            return _myDBContext.KitapHarekets.Where(u => u.Kitap.IsDeleted == false).ToList();
        }
        public KitapHareket GetKitapHareketByID(int id)
        {
            return _myDBContext.KitapHarekets.Where(u => u.ID == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _myDBContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateKitapHareket(KitapHareket kitap)
        {
            _myDBContext.Update(kitap);
            return Save();
        
        }

      
    }
}
