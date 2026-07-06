using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Passenger
    {
        private static int counter = 1;
        public string PassengerId { get;  } //unique
        public string PassengerName { get; set; }
        public string PassengerEmail { get; set; }
        public string PassengerPhone { get; set; }
        public string PassportNumber { get; set; } //unique
        public string PassengerNationality { get; set; }

        public Passenger()
        {
            PassengerId = "P" + counter.ToString("D3");
            counter++;
        }
    }
}
