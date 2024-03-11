using FlightBooking.Models;

namespace FlightBooking.Interface
{
    public interface IUserDetailsService
    {
        //Task<List<UserDetails>> GetSignupsAsync();
        //Task<UserDetails> GetSignupAsync(string email);
        Task<string> AddSignupAsync(UserDetails signup);
        Task<string> UpdateSignupAsync(string email, int age, string password);
        Task<string> DeleteSignupAsync(string email);
    }
}
