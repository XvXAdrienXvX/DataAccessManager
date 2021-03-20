using DataAccessManager.Repository;
using System;

namespace DataAccessManager.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DBContext _context;

        #region Repositories
        private PaymentRepository _paymentRepository;
        #endregion

        public UnitOfWork()
        {
            var connection = DBConnectionHelper.CreateConnection();
            _context = new DBContext(connection.ConnectionString, true);
        }
        public IPaymentRepository paymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_context);
                }

                return _paymentRepository;
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
