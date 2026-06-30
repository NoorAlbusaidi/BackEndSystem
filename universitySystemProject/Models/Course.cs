using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Course
    {
        public string CourseId { get; set; }
        public string CourseCode { get; set; }

        public string CourseTitle { get; set; }
        public int CourseCreditHours { get; set; }
        public string DepartmentId { get; set; }
         
        public string InstructorId { get; set; }

        public string CourseSemesterOffered { get; set; }
    }
}
