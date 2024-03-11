using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Models
{
    public class PassengerDetails
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Passenger name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Passenger Gender is Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Passenger Age is Required")]
        public int Age { get; set; }
    }
}
