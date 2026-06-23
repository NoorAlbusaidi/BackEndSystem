using System;
using System.Collections.Generic;
using System.Text;

namespace flightManagementSystem.models
{
    internal class Booking
    {
        public int bookingId;
        public string seatNumber;
        public string bookingDate;
        public decimal BookingtotalPrice { get; private set; }
        public string BookingStatus; //Confirmed | Cancelled

        public decimal calculateTotalPrice(int price,int count) {
            BookingtotalPrice = price*count;
            return BookingtotalPrice;
        }

    }
}
