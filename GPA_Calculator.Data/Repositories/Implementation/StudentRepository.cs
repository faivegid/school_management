using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPA_Calculator.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace GPA_Calculator.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Student> _dbSet;



        public StudentRepository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = _context.Students;
        }


        public async Task<IEnumerable<Student>> GetAsync()
        {
            var students = await _dbSet.ToListAsync();
            return students;
        }


        public async Task<Student> GetAsync(string studentId)
        {
            var student = await _dbSet
                .Include(x => x.Courses)
                .FirstOrDefaultAsync(x => x.StudentId == studentId);
            return student;
        }


        public async Task<bool> CreateAsync(Student student)
        {
            await _dbSet.AddAsync(student);
            var row = await _context.SaveChangesAsync();
            return row > 0;
        }


        public async Task<bool> EditAsync(Student student)
        {
            _dbSet.Update(student);
            var row = await _context.SaveChangesAsync();
            return row > 0;
        }


        public async Task<bool> DeleteAsync(string studentId)
        {
            var student = await GetAsync(studentId);
            if (student != null)
            {
                _dbSet.Remove(student);
                var row = await _context.SaveChangesAsync();
                return row > 0;
            }
            return false;
        }
    }
}
