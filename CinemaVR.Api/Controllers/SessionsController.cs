using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private static readonly List<Session> _sessions = new();

        // GET: api/sessions
        [HttpGet]
        public ActionResult<IEnumerable<Session>> GetAll() => Ok(_sessions);

        // GET: api/sessions/5
        [HttpGet("{id}")]
        public ActionResult<Session> GetById(int id)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == id);
            return session == null ? NotFound() : Ok(session);
        }

        // POST: api/sessions
        [HttpPost]
        public ActionResult<Session> Create([FromBody] SessionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = new Session
            {
                Id = _sessions.Count == 0 ? 1 : _sessions.Max(s => s.Id) + 1,
                FilmId = dto.FilmId,
                Date = dto.Date,
                Hall = dto.Hall
            };

            _sessions.Add(session);

            return CreatedAtAction(nameof(GetById), new { id = session.Id }, session);
        }

        // PUT: api/sessions/5
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] SessionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var session = _sessions.FirstOrDefault(s => s.Id == id);
            if (session == null)
                return NotFound();

            session.FilmId = dto.FilmId;
            session.Date = dto.Date;
            session.Hall = dto.Hall;

            return NoContent();
        }

        // DELETE: api/sessions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var session = _sessions.FirstOrDefault(s => s.Id == id);
            if (session == null)
                return NotFound();

            _sessions.Remove(session);
            return NoContent();
        }
    }
}
