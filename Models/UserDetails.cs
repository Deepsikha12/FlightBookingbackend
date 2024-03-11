using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FlightBooking.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Display(Name = "EmailAddress")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [Display(Name = "Age")]

        public int Age { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5)]

        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
