using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private static List<Film> Films = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(Films);

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var film = Films.FirstOrDefault(f => f.Id == id);
        return film == null ? NotFound() : Ok(film);
    }

    [HttpPost]
    public IActionResult Create(FilmDto dto)
    {
        var film = new Film
        {
            Id = Films.Count + 1,
            Title = dto.Title,
            Price = dto.Price,
            Genre = dto.Genre,
            Year = dto.Year
        };

        Films.Add(film);
        return Created($"api/films/{film.Id}", film);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, FilmDto dto)
    {
        var film = Films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();

        film.Title = dto.Title;
        film.Price = dto.Price;
        film.Genre = dto.Genre;
        film.Year = dto.Year;

        return Ok(film);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var film = Films.FirstOrDefault(f => f.Id == id);
        if (film == null) return NotFound();

        Films.Remove(film);
        return NoContent();
    }
}
