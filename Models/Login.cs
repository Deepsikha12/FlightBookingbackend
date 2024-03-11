using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Models
{
    public class Login
    {
        [Key]
        [EmailAddress(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
