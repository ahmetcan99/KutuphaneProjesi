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
        readonly IRepositoryKitap _repository;
        readonly IMapper _mapper;
        readonly MyDBContext _myDBContext;
        public KitapController(IRepositoryKitap repository,IMapper mapper,MyDBContext myDBContext)
        {
            _repository = repository;
            _mapper = mapper;
            _myDBContext = myDBContext;

        }

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Kitap>))]
        public IActionResult GetBooks()
        {
            var books= _mapper.Map<ICollection<KitapDto>>(_repository.GetBooks());
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
            var item= _mapper.Map<KitapDto>(_repository.GetBookByID(id));
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

        //[HttpGet("/yayınevis/{yayinEviID}")]
        //[ProducesResponseType(200, Type = typeof(Kitap))]
        //[ProducesResponseType(400)]
        //public IActionResult  GetKitapByAnPublishingHouse(int yayinEviID)
        //{
        //    var kitap=_mapper.Map<KitapDto>(_repository.GetBookByYayınEvi(yayinEviID));
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(kitap);
        //}

        //[HttpGet("{bookId}/yayinEvis")]
        //public IActionResult GetPublishHouseByABook(int bookId)
        //{
          
        //    var reviews = _mapper.Map<List<YayinEviDto>>(
        //        _repository.GetBooksByPublisherHouse(bookId));

        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    return Ok(reviews);
        //}
    }
}
