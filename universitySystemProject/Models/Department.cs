using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Department
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentBuildig { get; set; }
        public decimal DepartmentBudget { get; set; }
        public string HeadInstructorId { get; set; }
    }
}
