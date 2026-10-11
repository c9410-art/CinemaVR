using System.ComponentModel.DataAnnotations;

namespace CinemaVR.Api.DTO
{
    public class SessionDto
    {
        [Required]
        public int FilmId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(30)]
        public string Hall { get; set; } = "";
    }
}
