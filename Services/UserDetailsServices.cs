using FlightBooking.Interface;
using FlightBooking.Models;
using FlightBooking.Repository;

namespace FlightBooking.Services
{
    public class UserDetailsServices: IUserDetailsService
    {
        private readonly IUserDetailsRepository _repository;

        public UserDetailsServices(IUserDetailsRepository repository)
        {
            _repository = repository;
        }

        /*public async Task<List<UserDetails>> GetSignupsAsync()
        {
            return await _repository.GetSignupsAsync();
        }

        public async Task<UserDetails> GetSignupAsync(string email)
        {
            return await _repository.GetSignupAsync(email);
        }*/

        public async Task<string> AddSignupAsync(UserDetails signup)
        {
            return await _repository.AddSignupAsync(signup);
        }

        public async Task<string> UpdateSignupAsync(string email, int age, string password)
        {
            return await _repository.UpdateSignupAsync(email, age, password);
        }

        public async Task<string> DeleteSignupAsync(string email)
        {
            return await _repository.DeleteSignupAsync(email);
        }
    }
}
