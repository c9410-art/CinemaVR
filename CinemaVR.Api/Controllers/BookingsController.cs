using Microsoft.AspNetCore.Mvc;
using CinemaVR.Api.Models;
using CinemaVR.Api.DTO;

namespace CinemaVR.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private static List<Booking> Bookings = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(Bookings);

    [HttpPost]
    public IActionResult Create(BookingDto dto)
    {
        var booking = new Booking
        {
            Id = Bookings.Count + 1,
            SessionId = dto.SessionId,
            UserId = dto.UserId,
            Seat = dto.Seat,
            Price = 150
        };

        Bookings.Add(booking);
        return Created($"api/bookings/{booking.Id}", booking);
    }
}
