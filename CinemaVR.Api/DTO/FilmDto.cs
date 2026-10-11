using System.ComponentModel.DataAnnotations;

namespace CinemaVR.Api.DTO
{
    public class FilmDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = "";

        [Range(0, 1000)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; } = "";

        [Range(1900, 2100)]
        public int Year { get; set; }
    }
}
