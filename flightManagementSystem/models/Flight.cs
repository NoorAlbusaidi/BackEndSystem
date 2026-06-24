using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Flight
    {
        private static int counter = 1;
        public string FlightId { get;}
        public string AircraftId { get; set; }

        public string PilotId { get; set; }

        public int FlightDuration{ get; set; }
        public string FlightCode { get; set; }
        public string FlightOrigin { get; set; } //Departure airport / city
        public string FlightDestination { get; set; } //Arrival airport / city
        public string FlightDepartureDate { get; set; }
        public string FlightDepartureTime { get; set; }
        public decimal FlightTicketPrice { get; set; }
        public int AvailableSeats { get; set; }
        public string FlightStatus { get; set; }//Scheduled | Departed | Cancelled

        public Flight() {
            FlightId = "FL" + counter.ToString("D3");
            counter++;
            FlightStatus = "Scheduled";


        }
        public void availableSeatsDecrease() {
            AvailableSeats--;
        }
        public void availableSeatsIncrease()
        {
            AvailableSeats++;
        }


    }
}
