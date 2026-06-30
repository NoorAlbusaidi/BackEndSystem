using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; } //auto-generated

        [Required]
        [MaxLength(100)]
        public string InstructorName { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string InstructorEmail { get; set; }//user input

        [MaxLength(20)]
        public string? InstructorOfficeNum { get; set; } //? Optional (nullable values enabled)

        [Required]
        public DateTime InstructorHireDate { get; set; }//user input

        [Required]
        //int.MaxValue = largest possible value an int can store in C#.
        //typeof(decimal) = Get the type information for the decimal type.
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Salary must be greater than 0.")]
        public decimal InstructorSalary { get; set; }//user input

        [Required]
        [MaxLength(50)]
        public string InstructorAcademicTitle { get; set; }//user input
    }
}
