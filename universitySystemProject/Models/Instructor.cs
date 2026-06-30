using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Instructor
    {
        public int InstructorId { get; set; } //auto-generated
        public string InstructorName { get; set; } //user input
        public string InstructorEmail { get; set; }//user input
        public DateTime InstructorHireDate { get; set; }//user input
        public decimal InstructorSalary { get; set; }//user input
        public string InstructorAcademicTitle { get; set; }//user input
    }
}
