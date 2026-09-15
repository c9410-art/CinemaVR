namespace CinemaVR.Api.DTO;

public class SessionDto
{
    public int FilmId { get; set; }
    public DateTime Date { get; set; }
    public string Hall { get; set; } = "";
}
