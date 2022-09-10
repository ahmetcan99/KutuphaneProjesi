using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        readonly IRepositoryKitap _repositorykitap;
        readonly IMapper _mapper;
        readonly MyDBContext _myDBContext;
        readonly IRepositoryDurum _repositoryDurum;
        readonly IRepositoryYayinEvi _repositoryYayinEvi;
        public KitapController(IRepositoryKitap repositorykitap,IMapper mapper,MyDBContext myDBContext,IRepositoryDurum repositoryDurum,IRepositoryYayinEvi repositoryYayinEvi)
        {
            _repositorykitap = repositorykitap;
            _mapper = mapper;
            _myDBContext = myDBContext;
            _repositoryDurum = repositoryDurum;
            _repositoryYayinEvi = repositoryYayinEvi;

        }

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Kitap>))]
        public IActionResult GetBooks()
        {
            var books= _mapper.Map<ICollection<KitapDto>>(_repositorykitap.GetBook());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);
          
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kitap>))]
        [ProducesResponseType(400)]
        public IActionResult GetBookId(int id)
        {
            var item= _mapper.Map<KitapDto>(_repositorykitap.GetBookByID(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(item);
        }
        [HttpGet("input")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Kitap>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetBookByName(string input)
        {

            IQueryable<Kitap> sorgu = _myDBContext.Kitaps;
            if (!string.IsNullOrEmpty(input))
            {
                sorgu = sorgu.Where(a => a.Adi.Contains(input) || a.Yazari.Contains(input));

            }
            return await sorgu.ToListAsync();

            try
            {
                if (sorgu.Any())
                {
                    return Ok(sorgu);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "hata oluştu veya veri gelmiyor.");

            }
        }




        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateKitap([FromQuery] int durumId, [FromQuery] int  yayinId, [FromBody] KitapDto kitapCreate)
        {
            if (kitapCreate == null)
            {
                return BadRequest(ModelState);
            }

            var kitaps=_repositorykitap.GetBook().
                Where(k=>k.Yazari.Trim()==kitapCreate.Yazari.TrimEnd()
                &&k.Adi.Trim()==kitapCreate.Adi.TrimEnd()
                &&k.YayinEviId==kitapCreate.YayinEviId).FirstOrDefault();

            if (kitaps != null)
            {
                return BadRequest("Bu kitap bulunmaktadır.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var kitapmap = _mapper.Map<Kitap>(kitapCreate);
            kitapmap.Durum = _repositoryDurum.GetDurum(durumId);
            kitapmap.YayinEvi = _repositoryYayinEvi.GetYayinEvi(yayinId);

            if (!_repositorykitap.CreateKitap(kitapmap))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var!");
                return BadRequest(ModelState);
            }
            return Ok("Ekleme işlemi başarılı");


        }


        [HttpDelete("kitapId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteKitap(int kitapId, [FromBody]KitapDto kitapDelete)
        {
            if (kitapDelete == null)
            {
                return BadRequest(ModelState);
            }
            if (kitapId != kitapDelete.ID)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest();

            var reviewMap = _mapper.Map<Kitap>(kitapDelete);

            if (!_repositorykitap.DeleteKitap(reviewMap))
            {
                ModelState.AddModelError("","Ters giden bir şeyler var.");
                return StatusCode(500, ModelState);
            }
            return Ok("Silme işlemi başarılı");

        }


        [HttpPut("kitapId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateKitap(int kitapId, [FromBody] KitapDto kitapUpdate)
        {
            if(kitapUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (kitapId != kitapUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewMap = _mapper.Map<Kitap>(kitapUpdate);
            if (_repositorykitap.UpdateKitap(reviewMap))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var");
                
            }
            return Ok("Güncelleme işlemi başarılı");

            

        }




    }
}
