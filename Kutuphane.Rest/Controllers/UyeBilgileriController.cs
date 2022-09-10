using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyeBilgileriController : ControllerBase
    {
        //üye ekle ,sil ve güncelle işlmeleri yapıldı.
        //interface ve map ile bağlantı sağlandı
        readonly IRepositoryUye _repositoryUye;
        readonly IMapper _mapper;
        public UyeBilgileriController(IRepositoryUye repositoryUye, IMapper mapper)
        {
            _repositoryUye = repositoryUye;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType (200, Type=typeof(IEnumerable<UyeBilgileri>))]
        public IActionResult GetUyeBilgileri()
        {
            var uyeBilgileris = _mapper.Map<ICollection<UyeBilgileriDto>>(_repositoryUye.GetUyeBilgileris());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uyeBilgileris);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UyeBilgileri>))]
        public IActionResult GetUyeBilgileri(int id)
        {
            var uyeBilgileris = _mapper.Map<UyeBilgileriDto>(_repositoryUye.GetUyeBilgileri(id));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(uyeBilgileris);
        }

        [HttpDelete("{uyeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUyeBilgileri(int uyeId, [FromBody] UyeBilgileriDto uyedelete )
        {
          
            if (uyedelete == null)
            {
                return BadRequest(ModelState);
            }
            if (uyeId != uyedelete.ID)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var uyeMapper = _mapper.Map<UyeBilgileri>(uyedelete);

            if (!_repositoryUye.DeleteUyeBilgileri(uyeMapper))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var!");
                return StatusCode(500, ModelState);
            }
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut("{uyeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUye(int uyeId, [FromBody] UyeBilgileriDto uyeBilgileriUpdate)
        {
            if (uyeBilgileriUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (uyeId != uyeBilgileriUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var uyeMapper=_mapper.Map<UyeBilgileri>(uyeBilgileriUpdate);

            if (!_repositoryUye.UpdateUyeBilgileri(uyeMapper))
            {
                ModelState.AddModelError(" ", "Ters giden bir şeyler var!");
                return StatusCode(500, ModelState);
            }
            return Ok("Güncelleme işlemi başarılı");




        }


    }
}
