using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Pilot
    {
        public int PilotId { get; set; }
        public string PilotName { get; set; }
        public string pilotPhone { get; set; }

        public string LicenseNumber { get; set; }
        public int FlightHours { get; set; }

        //protect availability
        public bool IsAvailable { get; private set; }

        public Pilot() {
            IsAvailable = true;
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
