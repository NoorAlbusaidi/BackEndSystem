using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{

    internal class Booking
    {
        private static int counter = 1;
        public string BookingId { get;}
        public string PassengerId{ get; set; }
        public string FlightId { get; set; }
        public string FlightCode { get; set; }

        public string BookingseatNumber { get; set; }
        public DateTime bookingDate { get; private set; }
        public decimal BookingtotalPrice { get; set; }
        public string BookingStatus { get; set; } //Confirmed | Cancelled

        public Booking() {
            BookingId = "BK" + counter.ToString("D3");
            counter++;
            BookingStatus = "confirmed";
            bookingDate = DateTime.Today;
        }


    }
}
