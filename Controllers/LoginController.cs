using FlightBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly Flight_Context _context;

        public LoginController(IConfiguration configuration, Flight_Context context)
        {
            _configuration = configuration;
            _context = context;
        }

        private string GenerateToken(UserDetails User)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,User.Email),
                new Claim(ClaimTypes.Role ,User.Role)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issure"], _configuration["Jwt:Audience"],claims :claims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login login)
        {
            UserDetails? userCheck = await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(login.Email));

            if (userCheck == null)
            {
                return BadRequest("User Not found");
            }
            if (!userCheck.Password.Equals(login.Password))
            {
                return BadRequest("Invalid Password");
            }
            var token = GenerateToken(userCheck);
            return Ok(new { Token = token });
        }
    }
}
