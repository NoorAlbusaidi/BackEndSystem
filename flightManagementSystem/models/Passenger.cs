using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Passenger
    {
        public string PassengerId { get; set; } //unique
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassportNumber { get; set; } //unique
        public string PassengerNationality { get; set; }

    }
}
