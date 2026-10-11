using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> _users = new();

        // POST: api/users/register
        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserRegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                Id = _users.Count == 0 ? 1 : _users.Max(u => u.Id) + 1,
                Email = dto.Email,
                FullName = dto.FullName
            };

            _users.Add(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }
    }
}
