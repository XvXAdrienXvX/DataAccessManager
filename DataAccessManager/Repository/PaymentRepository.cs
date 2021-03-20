using DataAccessManager.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessManager.Repository
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DBContext context) : base(context)
        {
        }

        public async Task<int> CreatePayment(Payment entity)
        {          
            const string query = @"INSERT INTO payment VALUES(@member_no, @payment_dt, @payment_amt, @statement_no , @payment_code)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                 new SqlParameter("member_no", entity.member_no),
                 new SqlParameter("payment_dt", DateTime.Now),
                 new SqlParameter("payment_amt", entity.payment_amt),
                 new SqlParameter("statement_no", entity.statement_no),
                 new SqlParameter("payment_code", entity.payment_code)
            };

            return await base.AddAsync(query, parameters);
        }
    }
}
