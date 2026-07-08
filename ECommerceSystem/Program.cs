using ECommerceSystem.Models;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
namespace ECommerceSystem
{
    internal class Program
    {
        public static EcommerceContext context = new EcommerceContext();
        //easy
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

        public static void UpdateProductPriceAvailability() {
            int prductID;
            //THE PRODUCT 
            Console.Write("Enter the product id: ");
            prductID = int.Parse(Console.ReadLine());
            Product product = context.Products.FirstOrDefault(p => p.ProductId == prductID);

            //NEW VALUES
            Console.Write("Enter new price: ");
            decimal newPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Is the product available? (true/false): ");
            bool isAvailable = bool.Parse(Console.ReadLine());

            //update some of the product properties
            if (product != null)
            {
                product.ProductPrice = newPrice;
                product.ProductIsAvailable = isAvailable;
                context.SaveChanges(); //EF Core detects changes, sends UPDATE SQL
                Console.WriteLine("Product updated.");
            }
            else {
                Console.WriteLine("Could not find the product");
                return;
            }
            
        }

        public static void DeleteReview() {
            int deletedReviewId;
            Console.Write("Enter the review id you want to delete: ");
            deletedReviewId = int.Parse(Console.ReadLine());
            //Find --> searches by primary key only(checkes PKs)
            Review review = context.Reviews.Find(deletedReviewId);
            if (review != null)
            {
                context.Reviews.Remove(review);
                context.SaveChanges();
                Console.WriteLine("Review deleted.");
            }
            else {
                Console.WriteLine("Could not find the Review with this id: "+ deletedReviewId);
                return;
            }
        }

        public static void ViewAllProducts() {
            List<Product> products = context.Products.ToList();

            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }
            Console.WriteLine("\n===== Product Catalogue =====");

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}");
                Console.WriteLine($"Product Name: {product.ProductName}");
                Console.WriteLine($"Product Price: {product.ProductPrice:C}");
                Console.WriteLine($"Product Stock Quantity: {product.ProductStockQuantity}");
                Console.WriteLine($"Product Available: {product.ProductIsAvailable}");
                Console.WriteLine(new string('-', 40));
            }

        }

        public static void FilterProductsCategoryPrice() {
            int selectedCategoryID;
            decimal minPrice;
            decimal maxPrice;
            Console.Write("Enter the category ID: ");
            selectedCategoryID = int.Parse(Console.ReadLine());

            Console.Write("Enter your minimum price: ");
            minPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter your maximum price: ");
            maxPrice = decimal.Parse(Console.ReadLine());
            List<Product> filteredProducts = context.Products
                                             .Where(p=>p.CategoryId == selectedCategoryID && p.ProductPrice>=minPrice && p.ProductPrice <= maxPrice)
                                             .OrderBy(p => p.ProductPrice)
                                             .ToList();
            if (filteredProducts.Count == 0)
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (Product product in filteredProducts)
            {
                Console.WriteLine($"ID: {product.ProductId}");
                Console.WriteLine($"Name: {product.ProductName}");
                Console.WriteLine($"Price: {product.ProductPrice}");
                Console.WriteLine($"Stock Quantity: {product.ProductStockQuantity}");
                Console.WriteLine($"Available: {product.ProductIsAvailable}");
                Console.WriteLine(new string('-', 40));
            }
        }

        public static void AddCategory()
        {
            Console.Write("Enter Category Name: ");
            string categoryName = Console.ReadLine();

            // Check if the category already exists
            Category existingCategory = context.Categories.FirstOrDefault(c => c.CategoryName == categoryName);

            if (existingCategory != null)
            {
                Console.WriteLine("Category already exists.");
                return;
            }

            Console.Write("Enter Category Description: ");
            string? categoryDescription = Console.ReadLine();

            Console.Write("Enter Category Image URL (optional): ");
            string? categoryImageUrl = Console.ReadLine();

            Category category = new Category
            {
                CategoryName = categoryName,
                CategoryDescription = categoryDescription,
                CategoryImageUrl = categoryImageUrl
            };

            context.Categories.Add(category);
            context.SaveChanges();

            Console.WriteLine("Category added successfully.");
        }

        //Medium
        public static void  PlaceOrder() {
            string phoneNum;
            //by using phone number will find the user Id
            Console.Write("Enter your phone number: ");
            phoneNum = Console.ReadLine();

            User user = context.Users.FirstOrDefault(ph=>ph.UserPhoneNum == phoneNum);

            if (user == null) {
                Console.WriteLine("user not found");
                return;
            }
            //order details
            Console.Write("Enter Shipping Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter Payment Method: ");
            string paymentMethod = Console.ReadLine();

            // Create Order
            Order order = new Order
            {
                UserId = user.UserId,
                OrderShippingAddress = address,
                paymentMethod = paymentMethod,
                OrderTotalAmount = 0
            };

            // Save first to generate OrderId
            context.Orders.Add(order);
            context.SaveChanges();

            Console.WriteLine("\n===== Products =====");
            List<Product> products = context.Products.ToList();
            foreach (Product product in products)
            {
                Console.WriteLine($"{product.ProductId} - {product.ProductName} | Price: {product.ProductPrice} | Stock: {product.ProductStockQuantity}");
            }
            decimal totalAmount = 0;
            while (true) {
                Console.Write("\nEnter Product ID (0 to finish): ");
                int productId = int.Parse(Console.ReadLine());

                if (productId == 0)
                    break;

                Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);
                if (product == null)
                {
                    Console.WriteLine("Product not found.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero.");
                    continue;
                }

                if (quantity > product.ProductStockQuantity)
                {
                    Console.WriteLine("Insufficient stock.");
                    continue;
                }

                // Create bridge entity (OrderProduct)
                OrderProduct orderProduct = new OrderProduct
                {
                    OrderId = order.OrderId,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                    UnitPrice = product.ProductPrice
                };

                context.OrderProducts.Add(orderProduct);

                // Calculate total
                totalAmount += orderProduct.UnitPrice * quantity;

                // Reduce stock
                product.ProductStockQuantity -= quantity;

                // Update order total
                order.OrderTotalAmount = totalAmount;

                context.SaveChanges();

                Console.WriteLine("\nOrder placed successfully.");
                Console.WriteLine($"Order ID: {order.OrderId}");
                //:C --> display the value as currency
                Console.WriteLine($"Total Amount: {order.OrderTotalAmount:C}");
            }//while(true)

        }

        static void Main(string[] args)
        {

            int choice;
            Console.WriteLine("---Services---");
            Console.WriteLine("(1)  Register a new user");
            Console.WriteLine("(2)  Add a New Product to a Category");
            Console.WriteLine("(3)  Place an Order");
            Console.WriteLine("(4)  Write a Product Review");
            Console.WriteLine("(5)  Update Product Price and Availability");
            Console.WriteLine("(6)  ");
            Console.WriteLine("(7)  Delete a Review");
            Console.WriteLine("(8)  View All Products (Get All)");
            Console.WriteLine("(9)  Filter Products by Category and Price Range");
            Console.WriteLine("00. Add a category(testing)");
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
                        PlaceOrder();
                        break;

                    case 4:
                        WriteProductReview();
                        break;

                    case 5:
                        UpdateProductPriceAvailability();
                        break;

                    case 6:
                        break;

                    case 7:
                        DeleteReview();
                        break;

                    case 8:
                        ViewAllProducts();
                        break;

                    case 9:
                        FilterProductsCategoryPrice();
                        break;
                    case 00:
                        AddCategory();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }//switch (choice)
                Console.WriteLine("---Services---");
                Console.WriteLine("(1)  Register a new user");
                Console.WriteLine("(2)  Add a New Product to a Category");
                Console.WriteLine("(3)  Place an Order");
                Console.WriteLine("(4)  Write a Product Review");
                Console.WriteLine("(5)  Update Product Price and Availability");
                Console.WriteLine("(6)  ");
                Console.WriteLine("(7)  Delete a Review");
                Console.WriteLine("(8)  View All Products (Get All)");
                Console.WriteLine("(9)  Filter Products by Category and Price Range");
                Console.WriteLine("(00) Add a category(testing)");
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
