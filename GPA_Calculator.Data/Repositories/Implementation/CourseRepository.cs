using GPA_Calculator.Data.Repositories.Implementation;
using GPA_Calculator.Data.Repositories.Interfaces;
using GPA_Calculator.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Course>> GetStudentCoursesAsync(string studentId)
        {
            var student = await _context.Students.Where(st => st.StudentId == studentId)
                                  .Include(student => student.Courses)
                                  .FirstOrDefaultAsync();
            return student.Courses;
        }// end GetStudentCoursesAsync        
    }
}
