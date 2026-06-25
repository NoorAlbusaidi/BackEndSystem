using flightManagementSystem.models;
using Microsoft.Win32;
using System.Globalization;
using System.Numerics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Transactions;

namespace flightManagementSystem
{
    internal class Program
    {

        public static int aircraftTotalSeats;
        public static FlightContext context = new FlightContext
        {
            aircrafts = new List<Aircraft>(),
            bookings = new List<Booking>(),
            flights = new List<Flight>(),
            passengers = new List<Passenger>(),
            pilots = new List<Pilot>(),
            reports = new List<FlightReport>()
        };
        public static void RegisterPassenger()
        {
            string passengerName;
            string passengerEmail;
            string passengerPhoneNum;
            string passportNum;
            string nationality;
            int passengerCounter;
            string passengerId;

            //validate the passenger name
            Console.Write("Enter your name: ");
            passengerName = Console.ReadLine();
            passengerName = passengerName.Trim();

            //Regex --> "Does this text look like what I want?"
            while (string.IsNullOrWhiteSpace(passengerName) ||!Regex.IsMatch(passengerName, @"^[a-zA-Z\s]+$")) {
                Console.WriteLine("Invalid name. Try again");
                Console.Write("Enter your name: ");
                passengerName = Console.ReadLine();
                passengerName = passengerName.Trim();
            }

            //validate the email
            Console.Write("\nEnter your email: ");
            passengerEmail = Console.ReadLine();
            passengerEmail = passengerEmail.Trim();
            passengerEmail = passengerEmail.ToLower();

            while (string.IsNullOrWhiteSpace(passengerEmail) || !passengerEmail.EndsWith("@gmail.com")) {
                Console.WriteLine("Invalid email. Try again");
                Console.Write("\nEnter your email: ");
                passengerEmail = Console.ReadLine();
                passengerEmail = passengerEmail.Trim();
                passengerEmail = passengerEmail.ToLower();
            }

            //validating the phone number
            Console.Write("\nEnter your phone number: ");
            passengerPhoneNum = Console.ReadLine();
            passengerPhoneNum = passengerPhoneNum.Trim();

            while (string.IsNullOrWhiteSpace(passengerPhoneNum) || !Regex.IsMatch(passengerPhoneNum, @"^[0-9]+$") || passengerPhoneNum.Length!=8) {
                Console.WriteLine("Invalid phone number. Try again");
                Console.Write("\nEnter your phone number: ");
                passengerPhoneNum = Console.ReadLine();
                passengerPhoneNum = passengerPhoneNum.Trim();

            }


            //validating passport Number
            Console.Write("\nEnter your passport number: ");
            passportNum = Console.ReadLine();
            passportNum = passportNum.Trim();

            //{8} the length must be = 8
            while (string.IsNullOrWhiteSpace(passportNum) || !Regex.IsMatch(passportNum, @"^[a-zA-Z0-9]{8}$")|| context.passengers.Any(p => p.PassportNumber == passportNum))
            {
                Console.WriteLine("Invalid passport Number. Try again");
                Console.Write("\nEnter your passport number: ");
                passportNum = Console.ReadLine();
                passportNum = passportNum.Trim();

            }

            //validating nationality
            Console.Write("\nEnter your nationality: ");
            nationality = Console.ReadLine();
            nationality = nationality.Trim();

            //[a-zA-Z]+: by addidng + can have more than one letter without + means one char
            while (string.IsNullOrWhiteSpace(nationality) || !Regex.IsMatch(nationality, @"^[a-zA-Z]+$"))
            {
                Console.WriteLine("Invalid nationality. Try again");
                Console.Write("\nEnter your nationality: ");
                nationality = Console.ReadLine();
                nationality = nationality.Trim();

            }


            //add a passenger
            Passenger p = new Passenger
            {
                PassengerName = passengerName,
                PassengerEmail = passengerEmail,
                PassengerPhone = passengerPhoneNum,
                PassportNumber = passportNum,
                PassengerNationality = nationality,
            };

            context.passengers.Add(p);

            Console.WriteLine("Passenger added successfully with id: "+ p.PassengerId);

        }

        public static void AddAircraft() {
            string model;
            int totalSeats;

            //validating the model
            Console.Write("Enter the aircraft's model: ");
            model = Console.ReadLine();
            model = model.Trim();
            
            while (string.IsNullOrWhiteSpace(model) || !Regex.IsMatch(model, @"^[a-zA-Z0-9-\s]+$"))
            {
                Console.WriteLine("Invalid model. Try again");
                Console.Write("Enter the aircraft's model: ");
                model = Console.ReadLine();
                model = model.Trim();

            }

            //validating total seats
            Console.Write("Enter the total seats of the aircraft: ");
            while (!int.TryParse(Console.ReadLine(), out totalSeats))
            {
                Console.WriteLine("Invalid number of seats");
                Console.Write("Enter the total seats of the aircraft: ");
            }
            aircraftTotalSeats = totalSeats;

            //add an Aircraft
            Aircraft a = new Aircraft
            {
                AircraftModel = model,
                TotalSeats=totalSeats,
            };

            context.aircrafts.Add(a);

            Console.WriteLine("Aircraft added successfully with id: " + a.AircraftId);
        }

        public static void RegisterPilot() {
            string pilotName;
            string pilotPhoneNum;
            string licenseNum;

            Console.Write("Enter pilot name: ");
            pilotName = Console.ReadLine();
            pilotName = pilotName.Trim();

            //Regex --> "Does this text look like what I want?"
            while (string.IsNullOrWhiteSpace(pilotName) || !Regex.IsMatch(pilotName, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Invalid name. Try again");
                Console.Write("Enter your name: ");
                pilotName = Console.ReadLine();
                pilotName = pilotName.Trim();
            }

            //validating the phone number
            Console.Write("\nEnter pilot phone number: ");
            pilotPhoneNum = Console.ReadLine();
            pilotPhoneNum = pilotPhoneNum.Trim();

            while (string.IsNullOrWhiteSpace(pilotPhoneNum) || !Regex.IsMatch(pilotPhoneNum, @"^[0-9]+$") || pilotPhoneNum.Length != 8)
            {
                Console.WriteLine("Invalid phone number. Try again");
                Console.Write("\nEnter pilot phone number: ");
                pilotPhoneNum = Console.ReadLine();
                pilotPhoneNum = pilotPhoneNum.Trim();

            }

            //validating the License Number
            Console.Write("\nEnter pilot license number: ");
            licenseNum = Console.ReadLine();
            licenseNum = licenseNum.Trim();

            while (string.IsNullOrWhiteSpace(licenseNum) || !Regex.IsMatch(licenseNum, @"^[a-zA-Z0-9-]+$"))
            {
                Console.WriteLine("Invalid license Number. Try again");
                Console.Write("\nEnter pilot license number: ");
                licenseNum = Console.ReadLine();
                licenseNum = licenseNum.Trim();

            }


            //add a pilot
            Pilot p = new Pilot
            {
                PilotName= pilotName,
                pilotPhone = pilotPhoneNum,
                PilotLicenseNumber = licenseNum,
            };

            context.pilots.Add(p);

            Console.WriteLine("Pilot added successfully with id: " + p.PilotId);

 


        }
       
        public static void ViewFlights() {
            if (context.flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }

            Console.WriteLine("\n--- All Flights ---");

            foreach (Flight f in context.flights)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Flight Code: " + f.FlightCode);
                Console.WriteLine("Origin: " + f.FlightOrigin);
                Console.WriteLine("Destination: " + f.FlightDestination);
                Console.WriteLine("Departure Date: " + f.FlightDepartureDate);
                Console.WriteLine("Departure Time: " + f.FlightDepartureTime);
                Console.WriteLine("Available Seats: " + f.AvailableSeats);
                Console.WriteLine("Ticket Price: " + f.FlightTicketPrice);
                Console.WriteLine("Status: " + f.FlightStatus);
            }

        }

    
        public static void ScheduleFlight() {
            string origin;
            string destination;
            DateTime date;
            DateTime time;
            decimal price;
            int durationMinutes;
            // select aircraft
            Console.Write("Enter Aircraft ID: ");
    string aircraftId = Console.ReadLine();
    aircraftId = aircraftId.Trim();
    while (string.IsNullOrWhiteSpace(aircraftId) || !Regex.IsMatch(aircraftId, @"^[A-Z0-9]+$"))
    {
        Console.WriteLine("\nInvalid aircraft id. Try again");
        Console.Write("Enter Aircraft ID: ");
        aircraftId = Console.ReadLine();
        aircraftId = aircraftId.Trim();

    }
    Aircraft selectedAircraft = context.aircrafts.FirstOrDefault(a => a.AircraftId == aircraftId);
    if (selectedAircraft == null) {
                Console.WriteLine("\nThere is no aircraft by this ID");
                return;
    }

    // select pilot
    Console.Write("Enter Pilot ID: ");
    string pilotId = Console.ReadLine();
            pilotId = pilotId.Trim();
            while (string.IsNullOrWhiteSpace(pilotId) || !Regex.IsMatch(pilotId, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid pilot id. Try again");
                Console.Write("Enter Pilot ID: ");
                pilotId = Console.ReadLine();
                pilotId = aircraftId.Trim();

            }
            Pilot selectedPilot = context.pilots.FirstOrDefault(p => p.PilotId == pilotId && p.IsAvailable);
            if (selectedPilot == null)
            {
                Console.WriteLine("\nThere is no pilot found by this ID or not available");
                return;
            }

            // input flight details
            //validating the origin
            Console.Write("Enter origin: ");
            origin = Console.ReadLine().Trim().ToLower();

            while (string.IsNullOrWhiteSpace(origin) || !Regex.IsMatch(origin, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Invalid origin. Letters only.");
                Console.Write("Enter origin: ");
                origin = Console.ReadLine().Trim().ToLower();
            }

            // validating the destination
            Console.Write("Enter destination: ");
            destination = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(destination) || !Regex.IsMatch(destination, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Invalid destination. Letters only.");
                Console.Write("Enter destination: ");
                destination = Console.ReadLine().Trim().ToLower();
            }

            //validating departure date
            Console.Write("Enter departure date(dd-MM-yyyy): ");
            while (!DateTime.TryParseExact(
           Console.ReadLine(),
           "dd-MM-yyyy",
           CultureInfo.InvariantCulture,
           DateTimeStyles.None,
           out date) || date.Date < DateTime.Today) //only accept today and future dates
            {
                Console.WriteLine("Invalid date.");
                Console.Write("Enter departure date (dd-MM-yyyy): ");
            }
            string dateStr = date.ToString("dd-MM-yyyy");

            //validating departure time
            Console.Write("Enter departure time(HH:mm): ");
            while (!DateTime.TryParseExact(
           Console.ReadLine(),
           "HH:mm",
           CultureInfo.InvariantCulture, //Ignore the computer’s language/region settings and use a fixed standard format
           DateTimeStyles.None, //Do NOT allow any extra formatting or adjustments
           out time))
            {
                Console.WriteLine("Invalid time format.");
                Console.Write("Enter departure time (HH:mm): ");
            }
            string timeStr = time.ToString("HH:MM tt");

            //validating ticket price
            Console.Write("Enter ticket price: ");
            while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
            {
                Console.WriteLine("Invalid price. Enter a positive number.");
                Console.Write("Enter ticket price: ");
            }

            //flight code
            string code;
            string[] airlines = { "EK", "QR", "BA" };
            Random rnd = new Random();

            do
            {
                code = airlines[rnd.Next(airlines.Length)] + rnd.Next(100, 999);
            }
            while (context.flights.Any(f => f.FlightCode == code));

            //flight duration
            Console.Write("Enter flight duration in minutes: ");
            while (!int.TryParse(Console.ReadLine(), out durationMinutes) || durationMinutes <= 0)
            {
                Console.WriteLine("Invalid duration. Enter positive minutes.");
                Console.Write("Enter flight duration in minutes: ");
            }

            // create a flight
            Flight f = new Flight
            {
                AircraftId = aircraftId,
                PilotId = pilotId,
                FlightOrigin = origin,
                FlightDestination = destination,
                FlightDepartureDate = dateStr,
                FlightDepartureTime = timeStr,
                FlightTicketPrice = price,
                AvailableSeats = selectedAircraft.TotalSeats,
                FlightCode = code,
                FlightDuration = durationMinutes,
            };

            // update pilot to isAvailable = false
            selectedPilot.AssignFlight();

            //add new flight
            context.flights.Add(f);

            Console.WriteLine("Flight scheduled successfully with code: " + f.FlightCode);

        }

        public static void BookFlight() {
            string passengerId;
            string destination;
            string code;
            int duration;
            int minutes;
            int hours;

            //Identify Passenger
            Console.Write("Enter Passenger ID: ");
            passengerId = Console.ReadLine().Trim();

           //validating the passenger id
            while (string.IsNullOrWhiteSpace(passengerId) || !Regex.IsMatch(passengerId, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid passenger Id. Try again");
                Console.Write("Enter Passenger ID: ");
                passengerId = Console.ReadLine().Trim();
            }
            Passenger passenger = context.passengers.FirstOrDefault(p => p.PassengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            //Choosing the destination
            Console.Write("Enter destination: ");
            destination = Console.ReadLine().Trim().ToLower();
            //validating
            while (string.IsNullOrWhiteSpace(destination) || !Regex.IsMatch(destination, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Invalid destination. Letters only.");
                Console.Write("Enter destination: ");
                destination = Console.ReadLine().Trim().ToLower();
            }

            //showing available flights with passenger destination
            List<Flight> availableFlights = context.flights
                                            .Where(f => f.FlightDestination == destination &&
                                             f.FlightStatus == "scheduled" &&
                                             f.AvailableSeats > 0)
                                             .ToList();


            Console.WriteLine("\nThe available flights of " + destination + " destination:");
            //Display the flights
            
            foreach (Flight f in availableFlights)
            {
                duration = f.FlightDuration;
                hours = duration / 60;
                minutes = duration % 60;

                Console.WriteLine($"Code: {f.FlightCode} \nSeats: {f.AvailableSeats} \nPrice: {f.FlightTicketPrice} \nDuration: {hours}h {minutes}m");
                Console.WriteLine("===================");
            }

            //select a flight
            Console.Write("Enter flight code: ");
            code = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(code) || !Regex.IsMatch(code, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid code. Try again");
                Console.Write("Enter flight code: ");
                code = Console.ReadLine().Trim();
            }

            Flight selectedFlight = availableFlights.FirstOrDefault(f => f.FlightCode == code);

            if (selectedFlight == null)
            {
                Console.WriteLine("No flight by this code.");
                return;
            }

            char[] columns = { 'A', 'B', 'C', 'D' }; // seats per row
            int seatsPerRow = columns.Length;
            Aircraft selectedAircraft = context.aircrafts.FirstOrDefault(a => a.AircraftId == selectedFlight.AircraftId);
            int bookedSeats = selectedAircraft.TotalSeats - selectedFlight.AvailableSeats;
            int row = (bookedSeats / seatsPerRow) + 1;
            int colIndex = bookedSeats % seatsPerRow;
            string seatNum = columns[colIndex] + row.ToString();

            //Create a Booking
            Booking booking = new Booking
            {
                PassengerId = passenger.PassengerId,
                FlightId = selectedFlight.FlightId,
                BookingtotalPrice = selectedFlight.FlightTicketPrice,
                BookingseatNumber = seatNum,
                FlightCode = selectedFlight.FlightCode,
            };

            //Decrease Available Seats
            selectedFlight.availableSeatsDecrease();

            //Save Booking
            context.bookings.Add(booking);

            Console.WriteLine("Booking successful with ID: "+ booking.BookingId);
            Console.WriteLine("Seat: " + booking.BookingseatNumber);
            Console.WriteLine("Price: " + booking.BookingtotalPrice+" OMR");

        }

        public static void CancelBooking() {
            string bookingId;
            Console.Write("Enter Booking ID: ");
            bookingId = Console.ReadLine();

            //validating the id
            while (string.IsNullOrWhiteSpace(bookingId) || !Regex.IsMatch(bookingId, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid booking Id. Try again");
                Console.Write("Enter booking ID: ");
                bookingId = Console.ReadLine().Trim();
            }

            Booking booking = context.bookings.FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                Console.WriteLine("Booking not found.");
                return;
            }

            //Check if already cancelled
            if (booking.BookingStatus.ToLower() == "cancelled")
            {
                Console.WriteLine("Booking is already cancelled.");
                return;
            }

            //Find the Flight
            Flight flight = context.flights.FirstOrDefault(f => f.FlightId == booking.FlightId);

            if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            //Update Booking
            booking.BookingStatus = "cancelled".ToLower();

            //Return Seat to Flight
            flight.availableSeatsIncrease();

            //Free the seat
            booking.BookingseatNumber = null;

            Console.WriteLine("Booking cancelled successfully.");

            //view details of cancelled booking
            List <Booking> cancelledBookings = context.bookings
                                                .Where(b => b.BookingStatus.ToLower() == "cancelled")
                                                .ToList();

            if (cancelledBookings.Count == 0) {
                Console.WriteLine("No cancelled bookings found.");
                return;
            }

            foreach (Booking b in cancelledBookings)
            {
                Console.WriteLine("\nCancelled booking details: ");
                Console.WriteLine("Booking ID: " + b.BookingId);
                Console.WriteLine("Passenger ID: " + b.PassengerId);
                Console.WriteLine("Flight Code: " + b.FlightCode);
            }
        }

        public static void DepartFlight() {
            string code;
            Console.Write("Enter flight code: ");
            code = Console.ReadLine().Trim().ToUpper();

            //validate the flight code
            while (string.IsNullOrWhiteSpace(code) || !Regex.IsMatch(code, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid code. Try again");
                Console.Write("Enter flight code: ");
                code = Console.ReadLine().Trim().ToUpper();
            }
            Flight selectedFlight = context.flights.FirstOrDefault(f => f.FlightCode == code);

            //while because you are in the departure phase
            while (selectedFlight == null)
            {
                Console.WriteLine("Flight not found. Try again.");
                Console.Write("Enter flight code: ");
                code = Console.ReadLine().Trim().ToUpper();

                //what I want to test every time in while
                selectedFlight = context.flights.FirstOrDefault(f => f.FlightCode.Equals(code, StringComparison.OrdinalIgnoreCase));
            }
            //flight cannot be departed if has no bookings
            var flightCodes = context.bookings.Where(f => f.FlightCode == selectedFlight.FlightCode).ToList();
            if (flightCodes.All(b=>b.BookingStatus == "cancelled")) {
                Console.WriteLine("Flight has no bookings can't be departed.");
                return;

            }
            //change the status to departed
            else if (selectedFlight.FlightStatus.ToLower() == "departed")
            {
                Console.WriteLine("Flight already departed.");
                return;
            }

            selectedFlight.FlightStatus = "departed";

            Pilot pilot = context.pilots.FirstOrDefault(p => p.PilotId == selectedFlight.PilotId);

            if (pilot != null)
            {
                pilot.PilotHours(selectedFlight.FlightDuration);
            }

            Console.WriteLine("Flight departed successfully.");
            selectedFlight.FlightDetails();
            pilot.PilotInfo();


        }

        public static void CancelFlight() {
            string flightCode;
            //Find the Flight
            Console.Write("Enter Flight Code: ");
            flightCode = Console.ReadLine().Trim().ToUpper();

            //validate the flight code
            while (string.IsNullOrWhiteSpace(flightCode) || !Regex.IsMatch(flightCode, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid code. Try again");
                Console.Write("Enter flight code: ");
                flightCode = Console.ReadLine().Trim().ToUpper();
            }
            Flight flight = context.flights.FirstOrDefault(f => f.FlightCode == flightCode);
            
            if (flight == null)
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            //Check if Already Cancelled
            if (flight.FlightStatus.ToLower() == "cancelled".ToLower())
            {
                Console.WriteLine("Flight is already cancelled.");
                return;
            }

            //Cancel the Flight
            flight.FlightStatus = "cancelled".ToLower();

            //Cancel Every Booking related to the cancelled flight
            List<Booking> affectedBookings = context.bookings
                                             .Where(b => b.FlightCode == flight.FlightCode &&
                                              b.BookingStatus.ToLower() == "confirmed".ToLower())
                                             .ToList();

            //cancel them
            foreach (Booking booking in affectedBookings)
            {
                booking.BookingStatus = "cancelled".ToLower();
                booking.BookingseatNumber = null;
                //increase the number of available seat
                flight.availableSeatsIncrease();
            }

            int cancelledCount = affectedBookings.Count;

            //Make Pilot Available Again
            Pilot pilot = context.pilots.FirstOrDefault(p => p.PilotId == flight.PilotId);

            if (pilot != null)
            {
                pilot.IsAvailable = true;
            }

            //confirm that all bookings are cancelled
            if (flight.AvailableSeats == aircraftTotalSeats)
            {
                Console.WriteLine("All bookings were successfully cancelled.");
                Console.WriteLine("Flight cancelled successfully.");
                Console.WriteLine($"{cancelledCount} booking(s) were cancelled.");
            }
            else
            {
                Console.WriteLine("Some seats are still occupied.");
            }

        }

        public static void PassengerBookingHistory() {
            //Identify paddenger id
            Console.Write("Enter Passenger ID: ");
            string passengerId = Console.ReadLine().Trim();

            //validating the passenger id
            while (string.IsNullOrWhiteSpace(passengerId) || !Regex.IsMatch(passengerId, @"^[A-Z0-9]+$"))
            {
                Console.WriteLine("\nInvalid passenger Id. Try again");
                Console.Write("Enter Passenger ID: ");
                passengerId = Console.ReadLine().Trim();
            }

            //Verify Passenger Exists
            Passenger passenger = context.passengers.FirstOrDefault(p => p.PassengerId == passengerId);

            if (passenger == null)
            {
                Console.WriteLine("Passenger not found.");
                return;
            }

            //Get All Bookings for This Passenger
            List<Booking> passengerBookings = context.bookings.Where(b => b.PassengerId == passengerId).ToList();

            if (passengerBookings.Count == 0)
            {
                Console.WriteLine("This passenger has no booking history.");
                return;
            }

            //Display Booking Details
            decimal totalSpent = 0;
            foreach (Booking booking in passengerBookings)
            {
                Flight flight = context.flights.FirstOrDefault(f => f.FlightCode == booking.FlightCode);

                Console.WriteLine("\n---Passenger History---");
                flight.FlightDetails();
                booking.viewBookingInfo();

                if (booking.BookingStatus.ToLower() == "confirmed".ToLower())
                {
                    totalSpent += booking.BookingtotalPrice;
                }
            }

            Console.WriteLine($"Total Spent (Confirmed Bookings): {totalSpent} OMR");
        }

        public static void FlightRevenueLoadFactorReport() {
            int confirmedBookings;
            decimal revenue;
            Aircraft aircraft;
            //Total Confirmed Bookings
            foreach (Flight flight in context.flights)
            {
                 confirmedBookings = context.bookings
                    .Count(b => b.FlightId == flight.FlightId &&
                                b.BookingStatus.ToLower() == "confirmed".ToLower());

                //Total Revenue
                revenue = context.bookings.Where(b => b.FlightId == flight.FlightId &&
                                   b.BookingStatus.ToLower() == "confirmed".ToLower())
                                  .Sum(b => b.BookingtotalPrice);


                // Aircraft assigned to this flight
                 aircraft = context.aircrafts.FirstOrDefault(a => a.AircraftId == flight.AircraftId);

                // Calculate load factor
                double loadFactor = 0;

                if (aircraft != null && aircraft.TotalSeats > 0)
                {
                    //(double)-->  division becomes floating-point division
                    loadFactor = (double)confirmedBookings / aircraft.TotalSeats * 100;
                }

                context.reports.Add(new FlightReport
                {
                    FlightCode = flight.FlightCode,
                    Route = flight.FlightOrigin + " -> " + flight.FlightDestination,
                    ConfirmedBookings = confirmedBookings,
                    Revenue = revenue,
                    LoadFactor = loadFactor
                });
            }

            context.reports = context.reports.OrderByDescending(r => r.Revenue).ToList();
            foreach (FlightReport item in context.reports)
            {
                Console.WriteLine("Flight Code: " + item.FlightCode);
                Console.WriteLine("Route: " + item.Route);
                Console.WriteLine("Confirmed Bookings: " + item.ConfirmedBookings);
                Console.WriteLine("Revenue: " + item.Revenue);
                Console.WriteLine("Load Factor: " + item.LoadFactor.ToString("F2") + "%");
            }

        }


        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("---Flight Management Services---");
            Console.WriteLine("(1)  Register a Passenger");
            Console.WriteLine("(2)  Add an Aircraft");
            Console.WriteLine("(3)  Register a Pilot");
            Console.WriteLine("(4)  View All Flights");
            Console.WriteLine("(5)  Schedule a Flight");
            Console.WriteLine("(6)  Book a Flight");
            Console.WriteLine("(7)  Cancel a Booking");
            Console.WriteLine("(8)  Depart a Flight");
            Console.WriteLine("(9)  Cancel a Flight");
            Console.WriteLine("(10) Passenger Booking History");
            Console.WriteLine("(11) Flight Revenue & Load Factor Report");
            Console.WriteLine("(0)  Exit");

            Console.Write("Enter your choice: ");
            //TryParse(): ignores leading and trailing spaces
            while (!int.TryParse(Console.ReadLine(), out choice)) {
                Console.WriteLine("Invalid choice you need to enter one number");
                Console.Write("Enter your choice: ");
            }

            while (choice != 0) {
                switch (choice) {
                    case 1:
                        RegisterPassenger();
                        break;
                    case 2:
                        AddAircraft();
                        break;
                    case 3:
                        RegisterPilot();
                        break;
                    case 4:
                        ViewFlights();
                        break;
                    case 5:
                        ScheduleFlight();
                        break;
                    case 6:
                        BookFlight();
                        break;
                    case 7:
                        CancelBooking();
                        break;
                    case 8:
                        DepartFlight();
                        break;
                    case 9:
                        CancelFlight();
                        break;
                    case 10:
                        PassengerBookingHistory();
                        break;
                    case 11:
                        FlightRevenueLoadFactorReport();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }//switch (choice)


                Console.WriteLine("\n---Services---");
                Console.WriteLine("(1)  Register a Passenger");
                Console.WriteLine("(2)  Add an Aircraft");
                Console.WriteLine("(3)  Register a Pilot");
                Console.WriteLine("(4)  View All Flights");
                Console.WriteLine("(5)  Schedule a Flight");
                Console.WriteLine("(6)  Book a Flight");
                Console.WriteLine("(7)  Cancel a Booking");
                Console.WriteLine("(8)  Depart a Flight");
                Console.WriteLine("(9)  Cancel a Flight");
                Console.WriteLine("(10) Passenger Booking History");
                Console.WriteLine("(11) Flight Revenue & Load Factor Report");
                Console.WriteLine("(0)  Exit");
                Console.Write("Enter your choice: ");
                
                //validate user choice
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice you need to enter one number");
                    Console.Write("Enter your choice: ");
                }

            }//while (choice != 0)

        }
    }
}
