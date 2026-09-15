using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionsController : ControllerBase
{
    private static List<Session> Sessions = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(Sessions);

    [HttpPost]
    public IActionResult Create(SessionDto dto)
    {
        var session = new Session
        {
            Id = Sessions.Count + 1,
            FilmId = dto.FilmId,
            Date = dto.Date,
            Hall = dto.Hall
        };

        Sessions.Add(session);
        return Created($"api/sessions/{session.Id}", session);
    }
}
