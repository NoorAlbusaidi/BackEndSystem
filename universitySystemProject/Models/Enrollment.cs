using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Enrollment
    {
        public string EnrollmentId { get; set; }
        public string StudentId { get; set; }

        public string CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FinalGrade { get; set; }

        public string Status { get; set; }

    }
}
