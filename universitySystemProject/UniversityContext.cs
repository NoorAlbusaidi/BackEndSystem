using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using universitySystemProject.Models;

namespace universitySystemProject
{
    internal class UniversityContext
    {
        public List<Department> departments { get; set; } 
        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }
        public List<Enrollment> enrollments { get; set; }
        public List<Instructor> instructors { get; set; }
       
    }
}
