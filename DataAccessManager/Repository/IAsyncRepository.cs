using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Repository
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllByIdAsync(int Id);
        Task<int> AddAsync(string query, List<SqlParameter> parameters = null);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
