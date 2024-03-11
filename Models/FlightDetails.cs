using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightBooking.Models
{
    public class FlightDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AeroId { get; set; }
        [Required]
        public string AeroName { get; set; }

        [Required]
        public string From_city { get; set; }

        [Required]
        public string To_city { get; set; }

        [Required]
        public DateTime Departure { get; set; }

        [Required]
        public DateTime Arrival { get; set; }

        [Required]
        public float Fare { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }
    }
}
