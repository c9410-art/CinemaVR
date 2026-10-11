namespace CinemaVR.Api.Models;

public class Session
{
    public int Id { get; set; }
    public int FilmId { get; set; }
    public DateTime Date { get; set; }
    public string Hall { get; set; } = "";
    public Film Film { get; set; } = null!;
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
