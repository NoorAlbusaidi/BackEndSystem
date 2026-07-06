using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; } // auto-generated

        [ForeignKey(nameof(user))]
        public int UserId { get; set; } 
        public User user { get; set; } //navigation property##

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now; // default value

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Price must be greater than 0.")]
        public decimal OrderTotalAmount { get; set; }

        [Required]
        [DefaultValue("pending")]
        [MaxLength(30)]
        public string OrderStatus { get; set; } //default value

        [Required]
        [MaxLength(300)]
        public string OrderShippingAddress { get; set; } //user input


        [Required]
        [MaxLength(50)]
        public string paymentMethod { get; set; } //user input

        //public ICollection<Product> Products { get; set; } //navigation property

        public virtual ICollection<Contain> ContainProducts { get; set; } //navigation property

    }
}
