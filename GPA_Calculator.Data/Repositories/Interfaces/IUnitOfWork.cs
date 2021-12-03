using System;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        Task<bool> SaveAllChangesAsync();
    }
}
