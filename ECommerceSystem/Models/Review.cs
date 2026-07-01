using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    internal class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; } //auto-generated

        [Required]
        [ForeignKey(nameof(user))]
        public int UserId { get; set; }
        public User user { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProduvtId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1,5)]
        public int ReviewRating { get; set; } // user input

        [MaxLength(1000)]
        public string? ReviewComment { get; set; } // user input

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now; //default value
    }
}
