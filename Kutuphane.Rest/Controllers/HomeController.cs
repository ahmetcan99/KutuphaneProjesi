using Kutuphane.Rest.Models;
using Microsoft.AspNetCore.Http;
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
        public ActionResult <UyeBilgileri> Register(UyeBilgileri uyeBilgileri)
        {
            _dbContext.UyeBilgileris.Add(uyeBilgileri);
            _dbContext.SaveChanges();
            return CreatedAtAction("",new UyeBilgileri { ID=uyeBilgileri.ID }); 
        }
    }
}
