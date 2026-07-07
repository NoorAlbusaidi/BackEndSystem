using ECommerceSystem.Models;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
namespace ECommerceSystem
{
    internal class Program
    {
        public static EcommerceContext context = new EcommerceContext();
        public static void RegisterNewUser() {
            string userName;
            string userEmail;
            string userFullName;
            string userPassword;
            string userPhoneNum;
            string userAddress;

            //username 
            Console.Write("Enter your user name: ");
            userName = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(userName) || !Regex.IsMatch(userName, @"^[a-zA-Z0-9_.]+$"))
            {
                Console.WriteLine("Invalid name. Try again");
                Console.Write("Enter your user name: ");
                userName = Console.ReadLine().Trim();        
            }
            
            //email
            Console.Write("\nEnter your email: ");
            userEmail = Console.ReadLine();
            
            while (string.IsNullOrWhiteSpace(userEmail) || !userEmail.EndsWith("@gmail.com"))
            {
                Console.WriteLine("Invalid email. Try again");
                Console.Write("\nEnter your email: ");
                userEmail = Console.ReadLine(); 
            }

            //full name
            Console.Write("Enter your full name: ");
            userFullName = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(userFullName) || !Regex.IsMatch(userFullName, @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Invalid name. Try again");
                Console.Write("Enter your full name: ");
                userFullName = Console.ReadLine().Trim();
            }

            //phone number
            Console.Write("\nEnter your phone number: ");
            userPhoneNum = Console.ReadLine().Trim();

            while (!Regex.IsMatch(userPhoneNum, @"^[0-9]+$") || userPhoneNum.Length != 8)
            {
                Console.WriteLine("Invalid phone number. Try again");
                Console.Write("\nEnter your phone number: ");
                userPhoneNum = Console.ReadLine().Trim();
            }

            //hashed pwds
            Console.Write("Enter your password: ");
            userPassword = Console.ReadLine();
            var hasher = new PasswordHasher<object>();
            //null --> because I want it only to hash the pwd
            string hashedPassword = hasher.HashPassword(null, userPassword);

            //User Address
            Console.Write("Enter your address: ");
            userAddress = Console.ReadLine();

            User newUser = new User
            {
                UserName = userName.ToLower(),
                UserEmail = userEmail.ToLower(),
                UserFullName = userFullName.ToLower(),
                UserPasswordHash = hashedPassword,
                UserPhoneNum = userPhoneNum,
                UserAddress = userAddress
            };
            context.Users.Add(newUser);
            context.SaveChanges();
            // After SaveChanges(), newUser.userId is now populated with the DB-assigned ID
            Console.WriteLine("New user ID: " + newUser.UserId);
        }
        static void Main(string[] args)
        {
            RegisterNewUser();
        }
    }
}
