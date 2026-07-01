using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(UserEmail), IsUnique = true)]
    internal class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } //auto-generated

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; } // user input 

        [Required]
        [MaxLength(150)]
        public string UserEmail { get; set; } // user input 

        [Required]
        [MaxLength(256)]
        public string UserPasswordHash { get; set; } //auto-generated

        [Required]
        [MaxLength(100)]
        public string UserFullName { get; set; } // user input 

        [MaxLength(20)]
        public string? UserPhoneNum { get; set; } // user input 

        [MaxLength(300)]
        public string? UserAddress { get; set; } // user input 

        [Required]
        public DateTime UserRegistrationDate { get; set; } = DateTime.Now; // auto-generated

        [DefaultValue(true)]
        public bool UserIsActive { get; set; } // default value

        public ICollection<Order> orders { get; set; } //navigation property#
        public ICollection<User> UserS { get; set; } //navigation property#

    }
}
