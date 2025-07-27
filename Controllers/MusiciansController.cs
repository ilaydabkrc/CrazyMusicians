using Microsoft.AspNetCore.Mvc;
using CrazyMusicians.Models;
using System.ComponentModel.DataAnnotations;

namespace CrazyMusicians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {
        // Coding english does not mean that only variable names are english :)
        private static List<Musician> _musicians = new List<Musician>
        {
            new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Famous Instrumentalist", FunFact = "Always plays the wrong note, but very fun" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popular Melody Writer", FunFact = "Songs are misunderstood but very popular" },
            new Musician { Id = 3, Name = "Cemil Akor", Profession = "Crazy Chordist", FunFact = "Changes chords often, but surprisingly talented" },
            new Musician { Id = 4, Name = "Fatma Nota", Profession = "Surprise Note Producer", FunFact = "Always prepares surprises while producing notes" },
            new Musician { Id = 5, Name = "Hasan Ritim", Profession = "Rhythm Monster", FunFact = "Does the rhythm in his own way, never fits but is funny" },
            new Musician { Id = 6, Name = "Elif Armoni", Profession = "Harmony Master", FunFact = "Sometimes plays harmonies wrong, but very creative" },
            new Musician { Id = 7, Name = "Ali Perde", Profession = "Curtain Player", FunFact = "Plays every curtain differently, always surprising" },
            new Musician { Id = 8, Name = "Ayşe Rezonans", Profession = "Resonance Expert", FunFact = "Expert in resonance, but sometimes makes a lot of noise" },
            new Musician { Id = 9, Name = "Murat Ton", Profession = "Tuning Enthusiast", FunFact = "Differences in tuning are sometimes funny, but very interesting" },
            new Musician { Id = 10, Name = "Selin Akor", Profession = "Chord Wizard", FunFact = "Creates a magical atmosphere when changing chords" }
        };

        // GET: api/musicians
        [HttpGet]
        public ActionResult<IEnumerable<Musician>> GetAll() => Ok(_musicians);

        // GET: api/musicians/{id}
        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Musician> GetById(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();
            return Ok(musician);
        }

        // GET: api/musicians/search?name=...&profession=...
        [HttpGet("search")]
        public ActionResult<IEnumerable<Musician>> Search([FromQuery] string? name, [FromQuery] string? profession)
        {
            var query = _musicians.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(profession))
                query = query.Where(m => m.Profession.Contains(profession, StringComparison.OrdinalIgnoreCase));
            return Ok(query.ToList());
        }

        // POST: api/musicians
        [HttpPost]
        public ActionResult<Musician> Create([FromBody] Musician musician)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            musician.Id = _musicians.Max(m => m.Id) + 1;
            _musicians.Add(musician);
            return CreatedAtAction(nameof(GetById), new { id = musician.Id }, musician);
        }

        // PUT: api/musicians/{id}
        [HttpPut("{id:int:min(1)}")]
        public IActionResult Update(int id, [FromBody] Musician updated)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();
            musician.Name = updated.Name;
            musician.Profession = updated.Profession;
            musician.FunFact = updated.FunFact;
            return NoContent();
        }

        // PATCH: api/musicians/{id}/funfact
        [HttpPatch("{id:int:min(1)}/funfact")]
        public IActionResult UpdateFunFact(int id, [FromBody][Required][StringLength(150)] string funFact)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();
            musician.FunFact = funFact;
            return NoContent();
        }

        // DELETE: api/musicians/{id}
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult Delete(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();
            _musicians.Remove(musician);
            return NoContent();
        }
    }
}
