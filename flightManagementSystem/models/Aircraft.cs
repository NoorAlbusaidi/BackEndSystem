using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Aircraft
    {
        private static int counter = 1;
        public string AircraftId { get;}
        public string AircraftModel { get; set; }
        public int TotalSeats { get; set; }
        public bool IsOperational { get; private set; }

        public Aircraft() {
            IsOperational = true; //airworthy
            AircraftId = "A" + counter.ToString("D3");
            counter++;
        }

        public void maintenance() {
            IsOperational = false;

        }
    }
}
