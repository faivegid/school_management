using System;
using System.ComponentModel.DataAnnotations;

namespace GPA_Calculator.Models.ViewModels
{
    public class CourseViewmodel
    {
        public string CourseCode { get; set; }

        [Range(1,9)]
        [Required(ErrorMessage = "Course Unit must be 1-9")]
        public int CourseUnit { get; set; }

        [Range(0, 100)]
        [Required(ErrorMessage = "Score must be 0-100")]
        public int Score { get; set; }       
    }
}
