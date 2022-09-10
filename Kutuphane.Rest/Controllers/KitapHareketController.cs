using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapHareketController : ControllerBase
    {
        readonly IRepositoryKitapHareket _repositorykitaphareket;
        readonly IMapper _mapper;
        readonly MyDBContext _myDBContext;
        readonly IRepositoryUye _repositoryUye;
        readonly IRepositoryKitap _repositoryKitap;

        public KitapHareketController(IRepositoryKitapHareket repositorykitaphareket, IMapper mapper, MyDBContext myDBContext, IRepositoryUye repositoryUye, IRepositoryKitap repositoryKitap)
        {
            _repositorykitaphareket = repositorykitaphareket;
            _mapper = mapper;
            _myDBContext = myDBContext;
            _repositoryUye = repositoryUye;
            _repositoryKitap = repositoryKitap;
        }


        [HttpGet("/arşiv")]
      
        [ProducesResponseType(200, Type = typeof(IEnumerable<KitapHareket>))]
        public IActionResult GetKitapArşiv()
        {
            var books = _mapper.Map<ICollection<KitapHareketDto>>(_repositorykitaphareket.GetKitapHareketArşiv());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);

        }


        [HttpGet]
       
        [ProducesResponseType(200, Type = typeof(IEnumerable<KitapHareket>))]
        public IActionResult GetKitaps()
        {
            var books = _mapper.Map<ICollection<KitapHareketDto>>(_repositorykitaphareket.GetAllKitapHarekets());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);

        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateKitap([FromQuery] int kitapId, [FromQuery] int uyeId, [FromBody] KitapHareketDto kitapHareketCreate)
        {
            if (kitapHareketCreate == null)
            {
                return BadRequest(ModelState);
            }

          
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var kitapmap = _mapper.Map<KitapHareket>(kitapHareketCreate);
            kitapmap.Kitap= _repositoryKitap.GetBookByID(kitapId);
            kitapmap.UyeBilgileri = _repositoryUye.GetUyeBilgileri(uyeId);
           
            //kitapmap. = _repositoryKitap.GetBook(kitapId);
            //kitapmap.YayinEvi = _repositoryYayinEvi.GetYayinEvi(yayinId);

            if (!_repositorykitaphareket.CreateKitapHareket(kitapmap))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var!");
                return BadRequest(ModelState);
            }
            return Ok("Ekleme işlemi başarılı");


        }


        [HttpPut("{kitapHareketId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateKitapHareket(int kitapHareketId, [FromBody] KitapHareketDto kitapHareketUpdate)
        {
            if (kitapHareketUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (kitapHareketId != kitapHareketUpdate.ID)
            {
                return BadRequest("Id eşleme sorunu");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hareketMap=_mapper.Map<KitapHareket>(kitapHareketUpdate);

            if (_repositorykitaphareket.UpdateKitapHareket(hareketMap))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var,kontrol ediniz");
                
            }
            return Ok("Güncelleme başarılı.");
        }







    }
}
