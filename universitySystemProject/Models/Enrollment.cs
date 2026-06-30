using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace universitySystemProject.Models
{
    internal class Enrollment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public DateTime EnrollmentDate { get; set; }

        [MaxLength(2)]
        [RegularExpression(@"^(A|A\+|A\-|B|B\+|B\-|C|C\-|C\+|D|D\-|D\+|F)$")]
        public string? FinalGrade { get; set; }

        [Required]
        [MaxLength(20)]
        [DefaultValue("In Progress")]
        public string Status { get; set; }

    }
}
