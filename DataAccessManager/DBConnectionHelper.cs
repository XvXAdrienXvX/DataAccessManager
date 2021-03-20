using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DataAccessManager
{
    public static class DBConnectionHelper
    {
        private const string _connectionName = "CreditDB";    

        public static IDbConnection CreateConnection()
        {
            ConnectionStringSettings connectionString = GetConnectionString();
            string providerName = connectionString.ProviderName;

            RegisterProviderToFactory(providerName);
            var provider = GetDbProviderFromFactory(providerName);

            var connection = provider.CreateConnection();
            if (connection == null)
                throw new ConfigurationErrorsException(
                    string.Format("Failed to create a connection using the connection string named '{0}' in app / web.config.", providerName));

            connection.ConnectionString = connectionString.ConnectionString;
            connection.Open();

            return connection;
        }

        private static ConnectionStringSettings GetConnectionString()
        {
            var connection = ConfigurationManager.ConnectionStrings[_connectionName];

            if (connection == null)
            {
                throw new ConfigurationErrorsException(
                   string.Format("Connection string with name {0} not found", _connectionName));
            }

            return connection;
        }

        private static void RegisterProviderToFactory(string providerName)
        {
            DbProviderFactories.RegisterFactory(providerName, System.Data.SqlClient.SqlClientFactory.Instance);
        }

        private static DbProviderFactory GetDbProviderFromFactory(string providerName)
        {
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            if(provider == null)
            {
                throw new ConfigurationErrorsException(
                  string.Format("Failed to retrieve database provider {0}", providerName));
            }

            return provider;
        }
    }
}
