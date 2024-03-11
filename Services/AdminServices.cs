using FlightBooking.Interface;
using FlightBooking.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FlightBooking.Services
{
    public class AdminService : IAdminService
    {
        private readonly Flight_Context _signupContext;
        private readonly IConfiguration _configuration;

        public AdminService(IConfiguration configuration, Flight_Context signupContext)
        {
            _configuration = configuration;
            _signupContext = signupContext;
        }

        /*public Login AuthenticateUser(Login admin)
        {
            Login _admin = null;
            if (admin.Email == "Admin12@gmail.com" && admin.Password == "Adm!1234")
            {
                _admin = admin;
            }
            return _admin;
        }

        public string GenerateToken(Login login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issure"], _configuration["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/

        public List<FlightDetails> GetFlightDetails()
        {
            return _signupContext.FlightDetail.ToList();
        }

        public FlightDetails GetFlightDetail(string aeroId)
        {
            return _signupContext.FlightDetail.FirstOrDefault(x => x.AeroId == aeroId);
        }

        public string AddFlightDetails(FlightDetails details)
        {
            _signupContext.FlightDetail.Add(details);
            _signupContext.SaveChanges();
            return "Successfully Added Flight Details";
        }

        public string UpdateFlightDetails(string aeroId, string from_city, string to_city, DateTime departure, DateTime arrival, string airline_Name, string boarding_Class, float fare)
        {
            var update = _signupContext.FlightDetail.FirstOrDefault(x => x.AeroId == aeroId);
            if (update != null)
            {

                _signupContext.SaveChanges();
                return "Flight details updated";
            }
            else
            {
                return "No Details Found";
            }
        }

        public string DeleteFlightDetails(string aeroId)
        {
            var details = _signupContext.FlightDetail.FirstOrDefault(x => x.AeroId == aeroId);
            if (details != null)
            {
                _signupContext.Remove(details);
                _signupContext.SaveChanges();
                return "Successfully Deleted Flight Details";
            }
            else
            {
                return "No Flight Found";
            }
        }
    }
}
