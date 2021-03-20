using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager
{
    public interface ISQLUtility
    {
        void ExecuteQuery(string commandText, List<SqlParameter> parameters = null);
        Task<int> ExecuteAsync(string commandText, List<SqlParameter> parameters = null);
    }
}
