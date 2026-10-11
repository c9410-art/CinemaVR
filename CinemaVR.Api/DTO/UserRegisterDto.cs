using System.ComponentModel.DataAnnotations;

namespace CinemaVR.Api.DTO
{
    public class UserRegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = "";
    }
}
