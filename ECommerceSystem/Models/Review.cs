using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Review
    {
        public int ReviewId { get; set; } //auto-generated
        public int ReviewRating { get; set; } // user input

        public string ReviewComment { get; set; } // user input
        public DateTime ReviewDate { get; set; } //default value
    }
}
