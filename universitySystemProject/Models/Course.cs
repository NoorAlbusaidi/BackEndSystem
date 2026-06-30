using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Course
    {
        public string CourseId { get; set; } //system auto-generated
        public string CourseCode { get; set; } //system auto-generated

        public string CourseTitle { get; set; } //user input
        public int CourseCreditHours { get; set; }//user input
        public string DepartmentId { get; set; } //foreign key of the department (from list)

        public string InstructorId { get; set; }//foreign key of the Instructor (from list)

        public string CourseSemesterOffered { get; set; }//user input
    }
}
