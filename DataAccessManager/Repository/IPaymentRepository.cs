using DataAccessManager.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Repository
{
    public interface IPaymentRepository : IAsyncRepository<Payment>
    {
        Task<int> CreatePayment(Payment entity);
    }
}
