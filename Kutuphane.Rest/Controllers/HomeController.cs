using Kutuphane.Rest.Dto;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.Tools;
using Microsoft.AspNetCore.Mvc;


namespace Kutuphane.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly MyDBContext _dbContext;
        public HomeController(MyDBContext myDBContext)
        {
            _dbContext = myDBContext;

        }


        //post: api/Home
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] UyeBilgileri uyeBilgileri)
        {
            var dbuser = _dbContext.UyeBilgileris.Where(u => u.KullaniciAdi == uyeBilgileri.KullaniciAdi).FirstOrDefault();
            if (dbuser != null)
            {
                return BadRequest("Bu kullanıcı adı kullanılmakta.");
            }
            else
            {
                uyeBilgileri.UyeDurumu = "aktif";
                uyeBilgileri.Sifre = Sifreleme.HashPassword(uyeBilgileri.Sifre);
                _dbContext.UyeBilgileris.Add(uyeBilgileri);
                _dbContext.SaveChanges();
                return Ok("Kayıt işlemi başarıyla gerçekleşti");
            }
        }
        //post ap/home/login 
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UyeDto uyeBilgileri)
        {
            String password = Sifreleme.HashPassword(uyeBilgileri.Sifre);
            var dbuser = _dbContext.UyeBilgileris.Where(u => u.KullaniciAdi == uyeBilgileri.KullaniciAdi && u.Sifre == password).FirstOrDefault();

            if (dbuser == null)
            {
                return BadRequest("Kullanıcı adı  veya şifre hatalı!");
            }

            return Ok(dbuser);
        }

        //get: api/home/getbook
        [HttpGet]
        public ActionResult<IEnumerable<Kitap>> GetBooks()
        {
            return _dbContext.Kitaps;
        }

        //post : api/home/addbook
        [HttpPost]
        [Route("addBook")]
        public ActionResult AddBook([FromBody] Kitap kitap)
        {
            var dbname = _dbContext.Kitaps.Where(u => u.Adi == kitap.Adi).FirstOrDefault();
            if (dbname != null)
            {
                return BadRequest("Bu kitap kütühanede bulunmaktadır.Lütfen başka bir kitap bilgisi girmeyi deneyiniz.");

            }
            else
            {
                kitap.Durumu = 1;
                _dbContext.Kitaps.Add(kitap);
                _dbContext.SaveChanges();
                return Ok("Kitap ekleme işlemi başarı ile gerçekleşti.");
            }

        }

        [HttpDelete("{id}")]
        //[Route("deleteBook")]
        public ActionResult<Kitap> DeleteBookItem(int id)
        {
            var kitapItem = _dbContext.Kitaps.Find(id);
            if (kitapItem == null)
            {
                return NotFound();
            }
            _dbContext.Kitaps.Remove(kitapItem);
            _dbContext.SaveChanges();
            return kitapItem;
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Kitap kitap)
        {
            if (id != kitap.ID)
            {
                return BadRequest("Bu bilgilere sahip bir kitap bulunamadı ,güncelleme işlemi geçersiz");
            }
            _dbContext.Entry(kitap).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Ok("Güncelleme başarılı");
        }
        [HttpGet("GetById/{id}")]

        public ActionResult<Kitap> GetBookById(int id)
        {
            var kitapItem = _dbContext.Kitaps.Find(id);
            if (kitapItem == null)
            {
                return NotFound();
            }
            return kitapItem;
        }




        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetBookByName(string input)
        {

            IQueryable<Kitap> sorgu = _dbContext.Kitaps;
            if (!string.IsNullOrEmpty(input))
            {
                sorgu = sorgu.Where(a => a.Adi.Contains(input)||a.Yazari.Contains(input));

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








    }
}
