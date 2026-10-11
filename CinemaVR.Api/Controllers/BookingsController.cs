using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static readonly List<Booking> _bookings = new();

        // GET: api/bookings
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetAll() => Ok(_bookings);

        // GET: api/bookings/5
        [HttpGet("{id}")]
        public ActionResult<Booking> GetById(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            return booking == null ? NotFound() : Ok(booking);
        }

        // POST: api/bookings
        [HttpPost]
        public ActionResult<Booking> Create([FromBody] BookingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booking = new Booking
            {
                Id = _bookings.Count == 0 ? 1 : _bookings.Max(b => b.Id) + 1,
                SessionId = dto.SessionId,
                UserId = dto.UserId,
                Seat = dto.Seat,
                Price = 150
            };

            _bookings.Add(booking);

            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }

        // DELETE: api/bookings/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var booking = _bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null)
                return NotFound();

            _bookings.Remove(booking);
            return NoContent();
        }
    }
}
