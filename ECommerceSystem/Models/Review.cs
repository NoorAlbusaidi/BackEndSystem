using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    [Table("Reviews")]
    internal class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; } //auto-generated

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; } //navigation property##

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; } //navigation property##

        [Required]
        [Range(1,5)]
        public int ReviewRating { get; set; } // user input

        [MaxLength(1000)]
        public string? ReviewComment { get; set; } // user input

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now; //default value

        
    }
}
