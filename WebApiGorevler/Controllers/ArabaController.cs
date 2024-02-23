using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGorevler.Data;
using WebApiGorevler.DTOs;

namespace WebApiGorevler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabaController : ControllerBase
    {
        private readonly UygulamaDbContext _db;

        public ArabaController(UygulamaDbContext db)
        {
            _db = db;
        }

        // Görev5: Tum arabalari getiren bir API metodu
        [HttpGet("TumArabalar")]
        public IActionResult HepsiniGetir()
        {
            return Ok(_db.Arabalar.ToList());
        }


        // Görev6: id'ye göre araba getiren bir API metodu
        [HttpGet("IdYeGoreGetir")]
        public IActionResult GetArabaById(int id)
        {
            var araba = _db.Arabalar.FirstOrDefault(a => a.Id == id);

            if (araba == null)
            {
                return NotFound();
            }

            return Ok(araba);
        }

        // Görev7: Markasi icerisinde aratilan kelimeyi iceren arabalari getiren bir API metodu
        [HttpGet("MarkaAra")]
        public IActionResult GetArabalarByMarka(string marka)
        {
            var arabalar = _db.Arabalar.Where(a => a.Marka.Contains(marka)).ToList();

            if (!arabalar.Any())
            {
                return NotFound();
            }

            return Ok(arabalar);
        }

        // Görev8: Ikinci el arabalari getiren bir API metodu
        [HttpGet("IkinciEl")]
        public IActionResult GetIkinciElArabalar()
        {
            var ikinciElArabalar = _db.Arabalar.Where(a => a.IkinciElMi).ToList();

            if (!ikinciElArabalar.Any())
            {
                return NotFound("Araba bulunamadi");
            }

            return Ok(ikinciElArabalar);
        }

        // Görev9: Ikinci el olmayan arabalari getiren bir API metodu
        [HttpGet("IkinciElDegil")]
        public IActionResult GetIkinciElOlmayanArabalar()
        {
            var ikinciElOlmayanArabalar = _db.Arabalar.Where(a => !a.IkinciElMi).ToList();

            if (!ikinciElOlmayanArabalar.Any())
            {
                return NotFound("Araba bulunamadi");
            }

            return Ok(ikinciElOlmayanArabalar);
        }

        [HttpPost("ArabaEkle")]
        public IActionResult PostAraba(PostArabaDto araba)
        {

            if (ModelState.IsValid)
            {
                var yeni = new Araba()
                {
                    Marka = araba.Marka,
                    Fiyat = araba.Fiyat,
                    IkinciElMi = araba.IkinciElMi
                };

                _db.Arabalar.Add(yeni);
                _db.SaveChanges();
                return CreatedAtAction("HepsiniGetir", new { id = yeni.Id }, yeni);
                // return Ok("Eklendi!!");
                // return Ok(araba);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("ArabaGuncelle")] // güncelleme
        public IActionResult PutAraba(int id, Araba araba)
        {
            if (id != araba.Id)
            {
                return BadRequest();
            }

            if (!_db.Arabalar.Any(x => x.Id == id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Arabalar.Update(araba);
                _db.SaveChanges();
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("Sil")] // sil
        public IActionResult DeleteAraba(int id)
        {
            var item = _db.Arabalar.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _db.Arabalar.Remove(item);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("MarkaSil/{marka}")]
        public IActionResult DeleteArabaByBrand(string marka)
        {
            var arabalar = _db.Arabalar.Where(a => a.Marka == marka).ToList();
            if (!arabalar.Any())
            {
                return NotFound();
            }

            foreach (var araba in arabalar)
            {
                _db.Arabalar.Remove(araba);
            }

            _db.SaveChanges();

            return NoContent();
        }
    }
}
