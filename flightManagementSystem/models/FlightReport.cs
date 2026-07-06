using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class FlightReport
    {
        public string FlightCode { get; set; }
        public string Route { get; set; }
        public int ConfirmedBookings { get; set; }
        public decimal Revenue { get; set; }
        public double LoadFactor { get; set; }
    }
}
