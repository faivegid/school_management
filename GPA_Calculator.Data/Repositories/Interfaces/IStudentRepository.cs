using GPA_Calculator.Models.DomainModels;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetWithCourse(string studentId);
    }
}