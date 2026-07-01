using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Product
    {
        public int ProductId { get; set; } //auto-generated
        public string ProductName { get; set; } //user input
        public string ProductDescription { get; set; } // user input
        public decimal ProductPrice { get; set; } // user input
        public int ProductStockQuantity { get; set; } //user input
        public string ProductImageUrl { get; set; } // user input
        public  DateTime ProductCreatedAt { get; set; } //default value
        public bool ProductIsAvailable { get; set; } //default value

    }
}
