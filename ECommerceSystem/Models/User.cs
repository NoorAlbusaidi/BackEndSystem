using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class User
    {
        public int UserId { get; set; } //auto-generated
        public string UserName { get; set; } // user input 
        public string UserEmail { get; set; } // user input 
        public string UserPasswordHash { get; set; } //auto-generated
        public string UserFullName { get; set; } // user input 
        public string UserPhoneNum { get; set; } // user input 
        public string UserAddress { get; set; } // user input 
        public DateTime UserRegistrationDate { get; set; } // auto-generated
        public bool UserIsActive { get; set; } // default value

    }
}
