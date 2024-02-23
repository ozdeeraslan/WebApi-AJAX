using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiGorevler.Data;
using WebApiGorevler.DTOs;

namespace WebApiGorevler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtobusController : ControllerBase
    {
        private readonly UygulamaDbContext _db;

        public OtobusController(UygulamaDbContext db)
        {
            _db = db;
        }

        [HttpGet("TumOtobusler")]
        public IActionResult GetOtobus()
        {
            return Ok(_db.Otobusler.ToList());
        }

        [HttpPost("OtobusEkle")]
        public IActionResult OtobusEkle(PostOtobusDto otobus)
        {
            if (ModelState.IsValid)
            {
                var yeniOtobus = new Otobus
                {
                    YolcuKapasitesi = otobus.YolcuKapasitesi,
                    Marka = otobus.Marka,
                    KayitTarihi = DateTime.Now
                };

                _db.Otobusler.Add(yeniOtobus);
                _db.SaveChanges();

                return CreatedAtAction(nameof(GetOtobus), new { id = yeniOtobus.Id }, yeniOtobus);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        public IActionResult OtobusGuncelle(int id, PostOtobusDto guncellenecekOtobus)
        {
            var otobus = _db.Otobusler.Find(id);

            if (ModelState.IsValid)
            {
                if (otobus == null)
                {
                    return NotFound();
                }

                otobus.YolcuKapasitesi = guncellenecekOtobus.YolcuKapasitesi;
                otobus.Marka = guncellenecekOtobus.Marka;
                otobus.KayitTarihi = DateTime.Now;
                otobus.GuncellenmeTarihi = DateTime.Now;

                _db.SaveChanges();
                return NoContent();
            }
            return BadRequest(ModelState);

        }
    }
}
