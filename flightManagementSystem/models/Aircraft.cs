using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Aircraft
    {
        public int AircraftId { get; set; }
        public string AircraftModel { get; set; }
        public int TotalSeats { get; set; }
        public bool IsOperational { get; private set; }

        public Aircraft() {
            IsOperational = true; //airworthy
        }

        public void maintenance() {
            IsOperational = false;

        }
    }
}
