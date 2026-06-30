using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Department
    {
        public string DepartmentId { get; set; } //auto-generated
        public string DepartmentName { get; set; } //user input
        public string DepartmentBuildig { get; set; }//user input
        public decimal DepartmentBudget { get; set; }//user input
        public string HeadInstructorId { get; set; } //foreign key (from list)
    }
}
