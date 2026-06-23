using flightManagementSystem.models;
using Microsoft.Win32;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Transactions;

namespace flightManagementSystem
{
    internal class Program
    {

        public static FlightContext context = new FlightContext
        {
            aircrafts = new List<Aircraft>(),
            bookings = new List<Booking>(),
            flights = new List<Flight>(),
            passengers = new List<Passenger>(),
            pilots = new List<Pilot>()
        };
        public static void RegisterPassenger()
        {
            string passengerName;
            string passengerEmail;
            string passengerPhoneNum;
            string passportNum;
            string nationality;

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
            context.passengers.Add(new Passenger
            {
                PassengerName = passengerName,
                PassengerEmail = passengerEmail,
                PassengerPhone = passengerPhoneNum,
                PassportNumber = passportNum,
                PassengerNationality = nationality


            });






        }
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("---Services---");
            Console.WriteLine("(1)  Register a Passenger");
            Console.WriteLine("(2)  Add an Aircraft");
            Console.WriteLine("(3)  Register a Pilot");
            Console.WriteLine("(4)  View All Flights");
            Console.WriteLine("(5)  Schedule a Flight");
            Console.WriteLine("(6)  Book a Flight");
            Console.WriteLine("(7)  Cancel a Booking");
            Console.WriteLine("(8)  Depart a Flight");
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
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }//switch (choice)
                Console.WriteLine("---Services---");
                Console.WriteLine("(1)  Register a Passenger");
                Console.WriteLine("(2)  Add an Aircraft");
                Console.WriteLine("(3)  Register a Pilot");
                Console.WriteLine("(4)  View All Flights");
                Console.WriteLine("(5)  Schedule a Flight");
                Console.WriteLine("(6)  Book a Flight");
                Console.WriteLine("(7)  Cancel a Booking");
                Console.WriteLine("(8)  Depart a Flight");
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
