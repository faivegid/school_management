using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPA_Calculator.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Course> _dbSet;


        public CourseRepository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = _context.Courses;
        }


        public async Task<IEnumerable<Course>> GetStudentCoursesAsync(string studentId)
        {
            var student = await _context.Students.Where(st => st.StudentId == studentId)
                                  .Include(student => student.Courses)
                                  .FirstOrDefaultAsync();
            return student.Courses;
        }


        public async Task<Course> GetAsync(string courseId)
        {
            var course = await _dbSet.FirstOrDefaultAsync(c => c.CourseId == courseId);
            return course;
        }


        public async Task<bool> CreateAsync(Course course)
        {
            await _dbSet.AddAsync(course);
            var row = await _context.SaveChangesAsync();
            return row > 0;
        }


        public async Task<bool> EditAsync(Course course)
        {
            _dbSet.UpdateRange(course);
            var row = await _context.SaveChangesAsync();
            return row > 0;
        }


        public async Task<bool> DeleteAsync(string courseId)
        {
            var course = await GetAsync(courseId);
            if (course != null)
            {
                _dbSet.Remove(course);
                var row = await _context.SaveChangesAsync();
                return row > 0;
            }
            return false;
        }
    }
}
