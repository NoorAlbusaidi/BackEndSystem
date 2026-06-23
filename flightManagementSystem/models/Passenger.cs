using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Passenger
    {
        public int passengerId { get; set; } //unique
        public string PassengerName { get; set; }
        public string passengerEmail { get; set; }
        public string passengerPhone { get; set; }
        public string passportNumber { get; set; } //unique
        public string PassengerNationality { get; set; }

    }
}
