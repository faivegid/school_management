 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPA_Calculator.Models.DomainModels
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        public int CourseUnit { get; set; }
        public string CourseCode { get; set; }
        public int Score { get; set; }
        public int GradeUnit { get; set; }
        public double Cumulative { get; set; }
        public char Grade { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
