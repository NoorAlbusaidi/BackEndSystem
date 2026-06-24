using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Flight
    {
        public int FlightId { get; set; }
        public string FlightCode { get; set; }
        public string FlightOrigin { get; set; } //Departure airport / city
        public string FlightDestination { get; set; } //Arrival airport / city
        public string FlightDepartureDate { get; set; }
        public string FlightDepartureTime { get; set; }
        public decimal FlightTicketPrice { get; set; }
        public int AvailableSeats { get; private set; }
        public string FlightStatus { get; set; }//Scheduled | Departed | Cancelled

        public void availableSeatsDecrease() {
            AvailableSeats--;
        }
        public void availableSeatsIncrease()
        {
            AvailableSeats++;
        }


    }
}
