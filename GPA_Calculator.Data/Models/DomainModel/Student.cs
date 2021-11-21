using System.Collections.Generic;

namespace GPA_Calculator.Models.DomainModels
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string SchoolName { get; set; }
        public string Class { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
