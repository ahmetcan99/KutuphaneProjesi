using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DurumController : ControllerBase
    {
        readonly IRepositoryDurum _repositoryDurum;
        readonly IMapper _mapper;
        public DurumController(IMapper mapper, IRepositoryDurum repositoryDurum)
        {
            _mapper = mapper;
            _repositoryDurum = repositoryDurum;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Durum>))]
        public IActionResult GetDurum()
        {
            var durums = _mapper.Map<ICollection<DurumDto>>(_repositoryDurum.GetDurums());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(durums);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Durum>))]
        public IActionResult GetDurum(int id)
        {
         

            var durum = _mapper.Map<DurumDto>(_repositoryDurum.GetDurum(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(durum);
        }

        [HttpGet("/kitaps/{kitapId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Durum))]
        public IActionResult GetDurumOfAnKitap(int kitapId)
        {
            var durum = _mapper.Map<DurumDto>(_repositoryDurum.GetDurumByKitap(kitapId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(durum);
        }

        [HttpGet("/durums/{durumId}")]
        [ProducesResponseType(400)]
        public IActionResult GetKitapByDurum(int durumId)
        {
            var kitap = _mapper.Map<ICollection<KitapDto>>(_repositoryDurum.GetKitapFromADurum(durumId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(kitap);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDurum([FromBody] DurumDto durumCreate)
        {
            if (durumCreate == null)
                return BadRequest(ModelState);

            var durum = _repositoryDurum.GetDurums()
            .Where(c => c.Aciklama.Trim().ToLower() == durumCreate.Aciklama.ToLower().ToUpper()).FirstOrDefault();

            if (durum != null)
            {
                ModelState.AddModelError(" ", "Eklenmek istenen durum mevcut");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var durumMap = _mapper.Map<Durum>(durumCreate);

            if(!_repositoryDurum.CreateDurum(durumMap))
            {
                ModelState.AddModelError(" ", "Hatalı");
                return StatusCode(500, ModelState);
            }

            return Ok("Ekleme işlemi başarılı");

        }

        [HttpDelete("{durumId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDurum(int durumId)
        {
            var durumDelete = _repositoryDurum.GetDurum(durumId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!_repositoryDurum.DeleteDurum(durumDelete))
            {
                ModelState.AddModelError(" ", "Hatalı");
            }
            return Ok("Silme Başarılı");
        }


        [HttpPut("{durumId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDurum(int durumId, [FromBody] DurumDto durumUpdate)
        {
            if (durumUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (durumId != durumUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest();

            var durumMap=_mapper.Map<Durum>(durumUpdate);

            if (!_repositoryDurum.UpdateDurum(durumMap))
            {
                ModelState.AddModelError(" ", "Hatalı");
                return StatusCode(500, ModelState);
         
            }
            return Ok("Güncelleme Başarılı");
        }

    }
}
