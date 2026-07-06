using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace universitySystemProject.Models
{
    [Index(nameof(CourseCode), IsUnique = true)]
    internal class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; } //system auto-generated

        [Required]
        [MaxLength(10)]
        [RegularExpression(@"^[A-Z]+[0-9]+$")]
        
        public string CourseCode { get; set; } //system auto-generated

        [Required]
        [MaxLength(150)]
        public string CourseTitle { get; set; } //user input

        [Required]
        [Range(1, 6)]
        public int CourseCreditHours { get; set; }//user input

        [ForeignKey(nameof(Department))] //to avoid renaming issue
        //without ? means not null
        public int DepartmentId { get; set; } //foreign key of the department (from list)
        public Department Department { get; set; } //navigation property##

        [ForeignKey(nameof(Instructor))] 
        //int? → Foreign key is optional(NULL allowed).
        public int? InstructorId { get; set; }//foreign key of the Instructor (from list)
        public Instructor Instructor { get; set; } //navigation property##

        [Required]
        [MaxLength(20)]
        public string CourseSemesterOffered { get; set; }//user input

        public ICollection<Student> Students { get; set; } //navigation property##
        //public ICollection<Enrollment> enrollments { get; set; } //navigation property#
    }
}
