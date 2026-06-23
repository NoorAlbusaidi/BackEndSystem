using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Flight
    {
        public int FlightId;
        public string FlightCode;
        public string FlightOrigin; //Departure airport / city
        public string FlightDestination; //Arrival airport / city
        public string departureDate;
        public string departureTime;
        public decimal ticketPrice; 
        public int availableSeats { get; private set; }
        public string FlightStatus;//Scheduled | Departed | Cancelled

        public void availableSeatsDecrease() {
            availableSeats--;
        }
        public void availableSeatsIncrease()
        {
            availableSeats++;
        }


    }
}
