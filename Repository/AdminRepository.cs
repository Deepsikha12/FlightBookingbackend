using FlightBooking.Models;

namespace FlightBooking.Repository
{
    public interface IAdminRepository
    {
        List<FlightDetails> GetFlightDetails();
        FlightDetails GetFlightDetail(string aeroId);
        void AddFlightDetails(FlightDetails details);
        void UpdateFlightDetails(FlightDetails details);
        void DeleteFlightDetails(FlightDetails details);
    }
    public class AdminRepository: IAdminRepository
    {
        private readonly Flight_Context _signupContext;

        public AdminRepository(Flight_Context signupContext)
        {
            _signupContext = signupContext;
        }

        public List<FlightDetails> GetFlightDetails()
        {
            return _signupContext.FlightDetail.ToList();
        }

        public FlightDetails GetFlightDetail(string aeroId)
        {
            return _signupContext.FlightDetail.FirstOrDefault(x => x.AeroId == aeroId);
        }

        public void AddFlightDetails(FlightDetails details)
        {
            _signupContext.FlightDetail.Add(details);
            _signupContext.SaveChanges();
        }

        public void UpdateFlightDetails(FlightDetails details)
        {
            _signupContext.Update(details);
            _signupContext.SaveChanges();
        }

        public void DeleteFlightDetails(FlightDetails details)
        {
            _signupContext.Remove(details);
            _signupContext.SaveChanges();
        }
    }
}
