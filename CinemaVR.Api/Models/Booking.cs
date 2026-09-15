namespace CinemaVR.Api.Models;

public class Booking
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int UserId { get; set; }
    public string Seat { get; set; } = "";
    public decimal Price { get; set; }
}
