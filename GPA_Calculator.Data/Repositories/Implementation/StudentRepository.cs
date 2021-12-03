using GPA_Calculator.Data.Repositories.Implementation;
using GPA_Calculator.Data.Repositories.Interfaces;
using GPA_Calculator.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationContext context) : base(context)
        {
        }

        
        public async Task<Student> GetWithCourse(string studentId)
        {
            var student = await _dbSet.Where(x => x.StudentId == studentId)
                                      .Include(x => x.Courses)
                                      .FirstOrDefaultAsync();
            return student;
        }
    }
}
