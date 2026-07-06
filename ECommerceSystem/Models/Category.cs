using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceSystem.Models
{
    [Index(nameof(CategoryName), IsUnique = true)]
    internal class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } //auto-generated

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } //user input 

        [MaxLength(500)]
        public string? CategoryDescription { get; set; } //user input

        [MaxLength(300)]
        public string? CategoryImageUrl { get; set; } // user input

        public ICollection<Product> Products { get; set; } //navigation property##
    }
}
