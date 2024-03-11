using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Models
{
    public class Flight_Context:DbContext
    {
        public Flight_Context()
        {
        }

        public Flight_Context(DbContextOptions<Flight_Context> options) : base(options)
        {

        }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<FlightDetails> FlightDetail { get; set; }
        public DbSet<BookingDetails> BookingDetail { get; set; }

        public DbSet<PassengerDetails> PassengerDetail { get; set; }
    }
}
