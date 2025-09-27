using backend.Services;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
namespace backend.Controllers
{
    [ApiController]
    [Route("api/knjige")]
    public class KnjigeController : ControllerBase
    {
        private readonly IRepozitorijumKnjiga _repozitorijumKnjiga;
        public KnjigeController(IRepozitorijumKnjiga repozitorijumKnjiga)
        {
            _repozitorijumKnjiga = repozitorijumKnjiga;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Knjiga>> GetAllKnjige()
        {
            var knjige = _repozitorijumKnjiga.GetAllKnjige();
            return Ok(knjige);
        }
        [HttpGet("{id}")]
        public ActionResult<Knjiga> GetKnjigaById(int id)
        {
            var knjiga = _repozitorijumKnjiga.GetKnjigaById(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            return Ok(knjiga);
        }
        [HttpPost]
        public ActionResult AddKnjiga(Knjiga knjiga)
        {
            var postojecaKnjiga = _repozitorijumKnjiga.GetKnjigaByNaziv(knjiga.Naslov);
            if (postojecaKnjiga != null)
            {
                return BadRequest("Knjiga sa ovim nazivom već postoji.");
            }
            _repozitorijumKnjiga.AddKnjiga(knjiga);
            return CreatedAtAction(nameof(GetKnjigaById), new { id = knjiga.Id }, knjiga);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateKnjiga(int id, Knjiga knjiga)
        {
            if (id != knjiga.Id)
            {
                return BadRequest();
            }
            var existingKnjiga = _repozitorijumKnjiga.GetKnjigaById(id);
            if (existingKnjiga == null)
            {
                return NotFound();
            }
            _repozitorijumKnjiga.UpdateKnjiga(knjiga);
            return NoContent();
        }
        [HttpPost("{id}/kupi")]
        public ActionResult KupiKnjigu(int id)
        {
            var knjiga = _repozitorijumKnjiga.GetKnjigaById(id);
            if (knjiga == null)
            {
                return NotFound();
            }
            if (knjiga.KolicinaNaStanju <= 0)
            {
                return BadRequest("Nema na stanju.");
            }
            _repozitorijumKnjiga.KupiKnjigu(id);
            // Ponovo učitaj knjigu da bi vratio ažurirano stanje
            var updated = _repozitorijumKnjiga.GetKnjigaById(id);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteKnjiga(int id)
        {
            var existingKnjiga = _repozitorijumKnjiga.GetKnjigaById(id);
            if (existingKnjiga == null)
            {
                return NotFound();
            }
            _repozitorijumKnjiga.DeleteKnjiga(id);
            return NoContent();
        }
    }
}