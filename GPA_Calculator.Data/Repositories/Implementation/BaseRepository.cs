using GPA_Calculator.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Implementation
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        
        public BaseRepository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = _context.Set<TEntity>();
        }

        #region Basic database CRUD Operation
        public async Task CreateAsync(TEntity entity) => await _dbSet.AddAsync(entity);
        
        public void Delete(TEntity entity) =>_dbSet.Remove(entity);        

        public void Edit(TEntity entity) => _dbSet.Update(entity);

        public virtual async Task<IEnumerable<TEntity>> GetAsync() => await _dbSet.ToListAsync();        

        public async Task<TEntity> GetAsync(string emtityId) =>  await _dbSet.FindAsync(emtityId);
        #endregion
    }
}
