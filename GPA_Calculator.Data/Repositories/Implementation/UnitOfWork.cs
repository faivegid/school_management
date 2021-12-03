using GPA_Calculator.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<UnitOfWork> _logger;

        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;        


        public UnitOfWork(ILogger<UnitOfWork> logger, ApplicationContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public IStudentRepository StudentRepository => _studentRepository ??= new StudentRepository(_context);
        public ICourseRepository CourseRepository => _courseRepository ??= new CourseRepository(_context);

                
        /// <summary>
        /// This Method should be called at the end of a database operation,
        /// that changes the data in the database
        /// </summary>
        /// <returns>true if all changes made have been saved sucessfully</returns>
        public async Task<bool> SaveAllChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Saving Changes to database failed", ex);
                return false;
            }
        }// end SaveAllChangesAsync\

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
