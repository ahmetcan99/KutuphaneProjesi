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
    public class RegisterController : ControllerBase
    {
        readonly IRepositoryUye _repositoryUye;
        readonly IMapper _mapper;
        public RegisterController(IRepositoryUye repositoryUye,IMapper mapper)
        {
            _repositoryUye = repositoryUye;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Register([FromBody] UyeBilgileriDto register)
        {
            if(register == null)
            {
                return BadRequest(ModelState);
            }
            var createUye = _repositoryUye.GetUyeBilgileris()
                .Where(u => u.KullaniciAdi.ToLower() == register.KullaniciAdi.ToLower()).FirstOrDefault();

            if(createUye != null)
            {
                ModelState.AddModelError(" ", "Eklenmek istenen  kullanıcı adı kullanılmakta");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uyeMap = _mapper.Map<UyeBilgileri>(register);

            if (_repositoryUye.CreateUyeBilgileri(uyeMap))
            {
                ModelState.AddModelError(" ", "Hatalı bir kayıt");
            }
            return Ok("Kayıt işlemi başarılı");
        }

    }
}
