using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessManager.Repository
{
    public class BaseRepository<T> : SQLUtility, IAsyncRepository<T> where T : class
    {
        public BaseRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> AddAsync(string query, List<SqlParameter> parameters = null)
        {
            return await ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetAllByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
