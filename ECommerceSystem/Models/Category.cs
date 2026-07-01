using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Category
    {
        public int CategoryId { get; set; } //auto-generated
        public string CategoryName { get; set; } //user input 
        public string CategoryDescription { get; set; } //user input
        public string CategoryImageUrl { get; set; } // user input
    }
}
