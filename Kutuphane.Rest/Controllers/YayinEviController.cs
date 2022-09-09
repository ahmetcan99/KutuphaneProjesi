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
    public class YayinEviController : ControllerBase
    {
        readonly IRepositoryYayinEvi _repositoryYayinEvi;
        readonly IMapper _mapper;
        public YayinEviController(IRepositoryYayinEvi repositoryYayinEvi,IMapper mapper)
        {
            _repositoryYayinEvi=repositoryYayinEvi;
            _mapper=mapper; 
        }

        [HttpGet]
        [ProducesResponseType (200, Type= typeof(IEnumerable<Durum>))]
        public IActionResult GetYayinEvi()
        {
            var durums = _mapper.Map<ICollection<YayinEviDto>>(_repositoryYayinEvi.GetYayinEvis());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(durums);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<YayinEvi>))]
        public IActionResult GetDurum(int id)
        {


            var durum = _mapper.Map<YayinEviDto>(_repositoryYayinEvi.GetYayinEvi(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(durum);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDurum([FromBody] YayinEviDto yayinEviCreate)
        {
            if (yayinEviCreate == null)
                return BadRequest(ModelState);

            var yayinevi = _repositoryYayinEvi.GetYayinEvis()
            .Where(c => c.Adi.Trim().ToLower() == yayinEviCreate.Adi.ToLower().ToUpper()).FirstOrDefault();

            if (yayinevi != null)
            {
                ModelState.AddModelError(" ", "Eklenmek istenen durum mevcut");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var yayinMap = _mapper.Map<YayinEvi>(yayinEviCreate);

            if (!_repositoryYayinEvi.CreateYayinEvi(yayinMap))
            {
                ModelState.AddModelError(" ", "Hatalı");
                return StatusCode(500, ModelState);
            }

            return Ok("Ekleme işlemi başarılı");

        }
        [HttpDelete("{yayinId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteYayinEvi(int yayinId)
        {
            var yayinDelete = _repositoryYayinEvi.GetYayinEvi(yayinId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_repositoryYayinEvi.DeleteYayinEvi(yayinDelete))
            {
                ModelState.AddModelError(" ", "Hatalı");
            }
            return Ok("Silme Başarılı");
        }


        [HttpPut("{yayinId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDurum(int yayinId, [FromBody] YayinEviDto yayinUpdate)
        {
            if (yayinUpdate == null)
            {
                return BadRequest(ModelState);
            }
            if (yayinId != yayinUpdate.ID)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest();

            var yayinMap = _mapper.Map<YayinEvi>(yayinUpdate);

            if (!_repositoryYayinEvi.UpdateYayinEvi(yayinMap))
            {
                ModelState.AddModelError(" ", "Hatalı");
                return StatusCode(500, ModelState);

            }
            return Ok("Güncelleme Başarılı");
        }

    }
}
