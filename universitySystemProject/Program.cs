using System.Numerics;
using universitySystemProject.Models;

namespace universitySystemProject
{
    internal class Program
    {
        public static UniversityContext context = new UniversityContext
        {
            courses = new List<Course>(),
            departments = new List<Department>(),
            students = new List<Student>(),
            enrollments = new List<Enrollment>(),
            instructors = new List<Instructor>()
        };
        static void Main(string[] args)
        {


        }
    }
}

