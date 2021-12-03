using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GPA_Calculator.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(string emtityId);
    }
}
