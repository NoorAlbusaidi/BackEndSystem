using flightManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem
{
    internal class FlightContext
    {
        public List<Aircraft> aircrafts = new List<Aircraft>();
        public List<Booking> bookings = new List<Booking>();
        public List<Flight> flights = new List<Flight>();
        public List<Passenger> passengers = new List<Passenger>();
        public List<Pilot> pilots = new List<Pilot>();
    }
}
