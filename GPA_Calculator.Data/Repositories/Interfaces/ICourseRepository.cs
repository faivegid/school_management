using System.Collections.Generic;
using System.Threading.Tasks;
using GPA_Calculator.Models.DomainModels;

namespace GPA_Calculator.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<bool> CreateAsync(Course course);
        Task<bool> DeleteAsync(string courseId);
        Task<bool> EditAsync(Course course);
        Task<Course> GetAsync(string courseId);
        Task<IEnumerable<Course>> GetStudentCoursesAsync(string studentId);
    }
}