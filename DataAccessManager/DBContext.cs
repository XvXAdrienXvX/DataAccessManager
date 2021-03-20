using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessManager
{
    public class DBContext : IDisposable
    {
        private DbConnection _connection;
        private bool _ownsConnection;
        private DbTransaction _transaction;

        public DBContext(string connectionString,bool ownsConnection)
        {
            _connection = new SqlConnection(connectionString);
            _ownsConnection = ownsConnection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public DbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }
        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction have already been already been commited. Check your transaction handling.");
            }
            _transaction.Commit();
            _transaction = null;
        }
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
            if (_connection != null && _ownsConnection)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}
