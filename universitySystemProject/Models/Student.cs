using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public String StudentEmail { get; set; }

        public string StudentPhoneNum { get; set; }

        public DateTime StudentBirthDate { get; set; }

        public int StudentEnrollmentYear { get; set; }

        public decimal StudentGpa { get; set; }
    }
}
