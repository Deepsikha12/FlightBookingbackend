using FlightBooking.Interface;
using FlightBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetailsService _userService;
        private readonly Flight_Context booking_Context;
        private readonly Flight_Context flight_Context;

        public UserDetailsController(IUserDetailsService userService, Flight_Context Booking_Context, Flight_Context flight_Context)
        {
            _userService = userService;
            this.booking_Context = Booking_Context;
            this.flight_Context = flight_Context;
        }

        /*[HttpGet]
        [Route("GetSignups")]
        public async Task<IActionResult> GetSignups()
        {
            var signups = await _userService.GetSignupsAsync();
            return Ok(signups);
        }

        [HttpGet]
        [Route("GetSignup")]
        public async Task<IActionResult> GetSignup(string email)
        {
            var signup = await _userService.GetSignupAsync(email);
            if (signup != null)
                return Ok(signup);
            else
                return NotFound("No Account Found");
        }*/

        [HttpPost]
        [Route("AddSignup")]
        [AllowAnonymous]
        public async Task<IActionResult> AddSignup(UserDetails signup)
        {
            var result = await _userService.AddSignupAsync(signup);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateSignup")]
        public async Task<IActionResult> UpdateSignup(string email, int age, string password)
        {
            var result = await _userService.UpdateSignupAsync(email, age, password);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteSignup")]
        public async Task<IActionResult> DeleteSignup(string email)
        {
            var result = await _userService.DeleteSignupAsync(email);
            return Ok(result);
        }
        [HttpPost]
        [Route("BookingDetails")]
        public async Task<string> AddBookingAsync(BookingDetails BDetails)
        {
            try
            {
                string A_id = BDetails.AeroId;
                FlightDetails fob = flight_Context.FlightDetail.Where(x => x.AeroId == A_id).FirstOrDefault();
                //bool isFlightValid = await booking_Context.FlightDetail.AnyAsync(f => f.AeroId == BDetails.AeroId);
                BDetails.Flight.AeroName = fob.AeroName;
                BDetails.Flight.From_city = fob.From_city;
                BDetails.Flight.To_city = fob.To_city;
                BDetails.Flight.Departure = fob.Departure;
                BDetails.Flight.Arrival = fob.Arrival;
                BDetails.Flight.Fare = fob.Fare;
                BDetails.Flight.SeatingCapacity = fob.SeatingCapacity;


                await booking_Context.BookingDetail.AddAsync(BDetails);
                await booking_Context.SaveChangesAsync();
                return "Successfully Signed Up";
            }

            catch
            {
                throw new Exception();
            }

        }
    }
}
