using FlightBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBooking.Repository
{

    public interface IUserDetailsRepository
    {
        //Task<List<UserDetails>> GetSignupsAsync();
        //Task<UserDetails> GetSignupAsync(string email);
        Task<string> AddSignupAsync(UserDetails signup);
        Task<string> UpdateSignupAsync(string email, int age, string password);
        Task<string> DeleteSignupAsync(string email);
    }
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly Flight_Context _context;

        public UserDetailsRepository(Flight_Context context)
        {
            _context = context;
        }

        /*public async Task<List<UserDetails>> GetSignupsAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserDetails> GetSignupAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }*/

        public async Task<string> AddSignupAsync(UserDetails signup)
        {
            try
            {
                if (signup.Role == "User")
                {
                    await _context.Users.AddAsync(signup);
                    await _context.SaveChangesAsync();
                    return "Successfully Signed Up";
                }
                else
                {
                    return "Invalid Role";
                }
            }

            catch
            {
                throw new Exception();
            }

        }

        public async Task<string> UpdateSignupAsync(string email, int age, string password)
        {
            var update = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (update != null)
            {
                update.Age = age;
                update.Password = password;
                await _context.SaveChangesAsync();
                return "Account updated";
            }
            else
            {
                return "No Account Found";
            }
        }

        public async Task<string> DeleteSignupAsync(string email)
        {
            var signup = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (signup != null)
            {
                _context.Remove(signup);
                await _context.SaveChangesAsync();
                return "Successfully Deleted Account";
            }
            else
            {
                return "No Account Found";
            }
        }
    }
}
