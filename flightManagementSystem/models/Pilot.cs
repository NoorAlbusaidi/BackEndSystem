using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Pilot
    {
        private static int counter = 1;
        public string PilotId { get;}
        public string PilotName { get; set; }
        public string pilotPhone { get; set; }

        public string PilotLicenseNumber { get; set; }
        public int FlightHours { get; set; }

        //protect availability
        public bool IsAvailable { get; private set; }

        public Pilot() {
            IsAvailable = true;
            PilotId = "P" + counter.ToString("D3");
            counter++;
        }

        public void AssignFlight()
        {
            IsAvailable = false;
        }

        public void CompleteFlight()
        {
            IsAvailable = true;
        }
    }
}
