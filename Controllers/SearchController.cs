using FlightBooking.Models;
using FlightBooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly Flight_Context signup_Context;

        public SearchController(Flight_Context signup_Context)
        {
            this.signup_Context = signup_Context;
        }
        [HttpGet]
        [Route("SearchFlight")]
        public IActionResult GetFlight(string from_city, string to_city)
        {
            var flights = signup_Context.FlightDetail.Where(x => x.From_city == from_city && x.To_city == to_city).ToList();

            if (flights == null || flights.Count == 0)
            {
                return NotFound("No Flights Available");
            }

            
            return Ok(flights);
        }
    }
}
