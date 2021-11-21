using System.Collections.Generic;
using System.Threading.Tasks;
using GPA_Calculator.Models.DomainModels;

namespace GPA_Calculator.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> CreateAsync(Student student);
        Task<bool> DeleteAsync(string studentId);
        Task<bool> EditAsync(Student student);
        Task<IEnumerable<Student>> GetAsync();
        Task<Student> GetAsync(string studentId);
    }
}