using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> Users = new();

    [HttpPost("register")]
    public IActionResult Register(UserRegisterDto dto)
    {
        var user = new User
        {
            Id = Users.Count + 1,
            Email = dto.Email,
            FullName = dto.FullName
        };

        Users.Add(user);
        return Created($"api/users/{user.Id}", user);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return user == null ? NotFound() : Ok(user);
    }
}
