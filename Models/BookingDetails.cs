using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightBooking.Models
{
    public class BookingDetails
    {
        [Key]
        [MinLength(100)]
        public int BookingId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Flight")]
        public string AeroId { get; set; }

        [JsonIgnore]
        public FlightDetails Flight { get; set; }

        [ForeignKey("Passenger")]
        public int PassengerId { get; set; }
        public PassengerDetails Passenger { get; set; }

    }
}
