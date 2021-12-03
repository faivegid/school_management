using GPA_Calculator.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<IEnumerable<Course>> GetStudentCoursesAsync(string studentId);
    }
}