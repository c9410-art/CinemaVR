using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.DTO;
using CinemaVR.Api.Models;

namespace CinemaVR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        // Дані в пам'яті (вимога лабораторної)
        private static readonly List<Film> _films = new();

        // GET: api/films
        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetAll([FromQuery] string? genre)
        {
            var result = string.IsNullOrEmpty(genre)
                ? _films
                : _films.Where(f => f.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

            return Ok(result);
        }

        // GET: api/films/5
        [HttpGet("{id}")]
        public ActionResult<Film> GetById(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);
            if (film == null)
                return NotFound();

            return Ok(film);
        }

        // POST: api/films
        [HttpPost]
        public ActionResult<Film> Create([FromBody] FilmDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var film = new Film
            {
                Id = _films.Count == 0 ? 1 : _films.Max(f => f.Id) + 1,
                Title = dto.Title,
                Genre = dto.Genre,
                Price = dto.Price,
                Year = dto.Year
            };

            _films.Add(film);

            return CreatedAtAction(nameof(GetById), new { id = film.Id }, film);
        }

        // PUT: api/films/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] FilmDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var film = _films.FirstOrDefault(f => f.Id == id);
            if (film == null)
                return NotFound();

            film.Title = dto.Title;
            film.Genre = dto.Genre;
            film.Price = dto.Price;
            film.Year = dto.Year;

            return NoContent();
        }

        // DELETE: api/films/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);
            if (film == null)
                return NotFound();

            _films.Remove(film);

            return NoContent();
        }
    }
}
