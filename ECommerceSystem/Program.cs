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

        public static void AddNewProductCategory()
        {
            // Display all categories
            //tolist because it is dbset
            List<Category> categories = context.Categories.ToList();

            Console.WriteLine("===== Categories =====");

            foreach (Category category in categories)
            {
                Console.WriteLine($"{category.CategoryId} - {category.CategoryName}");

            }

            // Read category
            Console.Write("\nEnter Category Id: ");
            int categoryId = int.Parse(Console.ReadLine());

            // Check if category exists
            Category selectedCategory = context.Categories.Find(categoryId);

            if (selectedCategory == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            // Read product details
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Description: ");
            string productDescription = Console.ReadLine();

            Console.Write("Enter Price: ");
            decimal productPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Stock Quantity: ");
            int stockQuantity = int.Parse(Console.ReadLine());

            Console.Write("Enter Image URL (optional): ");
            string imageUrl = Console.ReadLine();

            // Create product
            Product product = new Product
            {
                ProductName = productName,
                ProductDescription = productDescription,
                ProductPrice = productPrice,
                ProductStockQuantity = stockQuantity,
                ProductImageUrl = imageUrl,

                //Relationship
                CategoryId = categoryId
            };

            // Save
            context.Products.Add(product);
            context.SaveChanges();

            Console.WriteLine("Product added successfully.");

        }

        public static void WriteProductReview() {
            //Display all users
            List<User> availableUsers = context.Users.ToList();
            Console.WriteLine("==== USERS ====");
            foreach (User u in availableUsers) {
                Console.WriteLine($"{u.UserId} --> {u.UserName}");
            }

            //Display all products 
            List<Product> availableProducts = context.Products.ToList();
            Console.WriteLine("\n==== PRODUCTS ====");
            foreach (Product p in availableProducts)
            {
                Console.WriteLine($"{p.ProductId} --> {p.ProductName}");
            }

            //data
            Console.Write("\nEnter User Id: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("\nEnter Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            Console.Write("\nEnter Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            Console.Write("\nEnter Comment (optional): ");
            string comment = Console.ReadLine();

            //looking for the user and product ids if they are exsit
            if (context.Users.Find(userId) == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (context.Products.Find(productId) == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            //creating the review
            Review review = new Review
            {
                UserId = userId,
                ProductId = productId,
                ReviewRating = rating,
                ReviewComment = comment,
            };

            context.Reviews.Add(review);
            context.SaveChanges();

            Console.WriteLine("Review added successfully.");
        }
        static void Main(string[] args)
        {

            int choice;
            Console.WriteLine("---Services---");
            Console.WriteLine("(1)  Register a new user");
            Console.WriteLine("(2)  Add a New Product to a Category");
            Console.WriteLine("(3)  ");
            Console.WriteLine("(4)  Write a Product Review");
            Console.WriteLine("(5)  ");
            Console.WriteLine("(6)  ");
            Console.WriteLine("(7)  ");
            Console.WriteLine("(8)  ");
            Console.WriteLine("(0)  Exit");

            Console.Write("Enter your choice: ");
            //TryParse(): ignores leading and trailing spaces
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice you need to enter one number");
                Console.Write("Enter your choice: ");
            }

            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        RegisterNewUser();
                        break;

                    case 2:
                        AddNewProductCategory();
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
                Console.WriteLine("(1)  Register a new user");
                Console.WriteLine("(2)  Add a New Product to a Category");
                Console.WriteLine("(3)  ");
                Console.WriteLine("(4)  Write a Product Review");
                Console.WriteLine("(5)  ");
                Console.WriteLine("(6)  ");
                Console.WriteLine("(7)  ");
                Console.WriteLine("(8)  ");
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
