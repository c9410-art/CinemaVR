using System.ComponentModel.DataAnnotations;

namespace CinemaVR.Api.DTO
{
    public class BookingDto
    {
        [Required]
        public int SessionId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Seat must be like A5, B10, etc.")]
        public string Seat { get; set; } = "";
    }
}
