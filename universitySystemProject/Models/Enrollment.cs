using System;
using System.Collections.Generic;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }

        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FinalGrade { get; set; }

        public string Status { get; set; }

    }
}
