using FlightBooking.Models;

namespace FlightBooking.Interface
{
    public interface IAdminService
    {
        //Login AuthenticateUser(Login admin);
        //string GenerateToken(Login login);
        List<FlightDetails> GetFlightDetails();
        FlightDetails GetFlightDetail(string aeroId);
        string AddFlightDetails(FlightDetails details);
        string UpdateFlightDetails(string aeroId, string from_city, string to_city, DateTime departure, DateTime arrival, string airline_Name, string boarding_Class, float fare);
        string DeleteFlightDetails(string aeroId);
    }
}
