namespace CinemaVR.Api.Models;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
    public string Genre { get; set; } = "";
    public int Year { get; set; }
}
