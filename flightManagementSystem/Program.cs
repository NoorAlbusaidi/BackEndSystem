using flightManagementSystem.models;
using System.Numerics;

namespace flightManagementSystem
{
    internal class Program
    {
        public static FlightContext context = new FlightContext
        {
            aircrafts = new List<Aircraft>(),
            bookings = new List<Booking>(),
            flights = new List<Flight>(),
            passengers = new List<Passenger>(),
            pilots = new List<Pilot>()
        };
        static void Main(string[] args)
        {
            
        }
    }
}
