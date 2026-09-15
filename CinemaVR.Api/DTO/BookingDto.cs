namespace CinemaVR.Api.DTO;

public class BookingDto
{
    public int SessionId { get; set; }
    public int UserId { get; set; }
    public string Seat { get; set; } = "";
}
