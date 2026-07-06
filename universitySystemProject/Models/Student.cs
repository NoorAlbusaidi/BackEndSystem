using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace universitySystemProject.Models
{
    
    internal class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } //system auto-generated

        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; } //user input

        [Required]
        [MaxLength(150)]
        public string StudentEmail { get; set; } //user input

        [MaxLength(20)]
        public string? StudentPhoneNum { get; set; }//user input

        [Required]
        public DateTime StudentBirthDate { get; set; }//user input

        [Required]
        [Range(2000,2030)]
        public int StudentEnrollmentYear { get; set; }//user input

        [Range(0.0, 4.0)]
        [DefaultValue(0.0)]
        public decimal StudentGpa { get; set; }//default value

        public ICollection<Course> Courses { get; set; } //navigation property##
        //public ICollection<Enrollment> enrollments { get; set; } //navigation property#

    }
}
