using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessManager
{
    public class SQLUtility : ISQLUtility
    {
        protected readonly DBContext _dbContext;

        public SQLUtility(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> ExecuteAsync(string commandText, List<SqlParameter> parameters = null)
        {
            int rowsAffected = 0;
            using (var command = _dbContext.CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = commandText;

                if (parameters.Count > 0)
                {
                    foreach(var param in parameters)
                    {
                        command.Parameters.Add(param);
                    }
                }

                rowsAffected = await command.ExecuteNonQueryAsync();


                if (rowsAffected > 0)
                {
                    return rowsAffected;
                }
                else
                {
                    return -1;
                }
            }

        }

        public void ExecuteQuery(string commandText, List<SqlParameter> parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
