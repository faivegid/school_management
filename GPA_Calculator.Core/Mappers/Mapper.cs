using System;
using GPA_Calculator.Models.DomainModels;
using GPA_Calculator.Models.ViewModels;

namespace GPA_Calculator.Core
{
    public class Mapper
    {
        public static Course MapToCourse(CourseViewmodel model)
        {
            var score = UnitCalculator.Gradescore(model.Score);

            return new Course()
            {
                CourseId = Guid.NewGuid().ToString(),
                Score = model.Score,
                CourseCode = model.CourseCode,
                CourseUnit = model.CourseUnit,
                Cumulative = model.CourseUnit * score.GradeUnit,
                Grade = score.Grade,
                GradeUnit = score.GradeUnit,
                Remarks = score.Remark
            };
        }   

        public static Student MapToStudent(StudentViewModel studentModel)
        {
            return new Student() {
                StudentId = Guid.NewGuid().ToString(),
                FullName = studentModel.FullName,
                SchoolName = studentModel.SchoolName,
                Class = studentModel.Class                
            };
        }
    }
}
