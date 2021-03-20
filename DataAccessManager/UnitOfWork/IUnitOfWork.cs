using DataAccessManager.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessManager.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPaymentRepository paymentRepository { get; }
        void Commit();
    }
}
