using AutoMapper;
using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly MyDBContext _dbContext;
        readonly IMapper _mapper;
        public LoginController(MyDBContext myDBContext ,IMapper mapper)
        {
            _dbContext = myDBContext;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UyeDto uyeBilgileri)
        {
            //String password = Sifreleme.HashPassword(uyeBilgileri.Sifre);
            var dbuser = _dbContext.UyeBilgileris.Where(u => u.KullaniciAdi == uyeBilgileri.KullaniciAdi && u.Sifre == uyeBilgileri.Sifre).FirstOrDefault();

            if (dbuser == null)
            {
                return BadRequest("Kullanıcı adı  veya şifre hatalı!");
            }

            return Ok(dbuser+"Giriş başarılı.");
        }
    }
}
