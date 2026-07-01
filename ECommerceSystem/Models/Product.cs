using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; } //auto-generated

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; } //user input

        [MaxLength(1000)]
        public string? ProductDescription { get; set; } // user input

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335",ErrorMessage = "Price must be greater than 0.")]
        public decimal ProductPrice { get; set; } // user input

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "quantity must be greater than 0.")]
        [DefaultValue(0)]
        public int ProductStockQuantity { get; set; } //user input

        [MaxLength(300)]
        public string? ProductImageUrl { get; set; } // user input

        [Required]
        public DateTime ProductCreatedAt { get; set; } = DateTime.Now; //default value

        [DefaultValue(true)]
        public bool ProductIsAvailable { get; set; } //default value

    }
}
