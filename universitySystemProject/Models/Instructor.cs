using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Instructor
    {
        public string InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string InstructorEmail { get; set; }
        public DateTime InstructorHireDate { get; set; }
        public decimal InstructorSalary { get; set; }
        public string InstructorAcademicTitle { get; set; }
    }
}
