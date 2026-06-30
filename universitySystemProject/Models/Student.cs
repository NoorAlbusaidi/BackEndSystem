using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Student
    {
        public string StudentId { get; set; } //system auto-generated
        public string StudentName { get; set; } //user input
        public string StudentEmail { get; set; } //user input

        public string StudentPhoneNum { get; set; }//user input

        public DateTime StudentBirthDate { get; set; }//user input

        public int StudentEnrollmentYear { get; set; }//user input

        public decimal StudentGpa { get; set; }//default value

        public Student() {

            StudentGpa = 0;
        }
    }
}
