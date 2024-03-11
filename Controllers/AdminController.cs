using FlightBooking.Interface;
using FlightBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        /*[HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login adminlogin)
        {
            IActionResult response = Unauthorized();
            var adminlogin_ = _adminService.AuthenticateUser(adminlogin);
            if (adminlogin_ != null)
            {
                var token = _adminService.GenerateToken(adminlogin_);
                response = Ok(new { token = token });
            }
            return response;
        }
        */
        [HttpGet]
        [Route("GetFlightDetails")]
        public List<FlightDetails> GetFlightDetails()
        {
            return _adminService.GetFlightDetails();
        }

        [HttpGet]
        [Route("GetFlightDetail")]
        public FlightDetails GetFlightDetail(string aeroId)
        {
            return _adminService.GetFlightDetail(aeroId);
        }

        [HttpPost]
        [Route("AddFlightDetails")]
        [AllowAnonymous]
        public string AddFlightDetails(FlightDetails details)
        {
            return _adminService.AddFlightDetails(details);
        }

        [HttpPut]
        [Route("UpdateFlightDetails")]
        public string UpdateFlightDetails(string aeroId, string from_city, string to_city, DateTime departure, DateTime arrival, string airline_Name, string boarding_Class, float fare)
        {
            return _adminService.UpdateFlightDetails(aeroId, from_city, to_city, departure, arrival, airline_Name, boarding_Class, fare);
        }

        [HttpDelete]
        [Route("DeleteFlightDetails")]
        public string DeleteFlightDetails(string aeroId)
        {
            return _adminService.DeleteFlightDetails(aeroId);
        }
    }
}
