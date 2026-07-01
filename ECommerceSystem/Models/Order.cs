using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Order
    {
        public int OrderId { get; set; } // auto-generated
        public DateTime OrderDate { get; set; } // default value
        public decimal OrderTotalAmount { get; set; } 
        public string OrderStatus { get; set; } //default value
        public string OrderShippingAddress { get; set; } //user input
        public string paymentMethod { get; set; } //user input


    }
}
