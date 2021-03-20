using DataAccessManager.Entites;
using DataAccessManager.UnitOfWork;
using System;

namespace DataAccessManager
{
    partial class Program
    {
        public class PaymentController
        {
            private IUnitOfWork _unitOfWork;
            
            public PaymentController()
            {
                 _unitOfWork = new DataAccessManager.UnitOfWork.UnitOfWork();
            }

            public void CreatePayment()
            {
                Payment payment = new Payment()
                {
                    member_no = 84,
                    payment_dt = DateTime.Now,
                    payment_amt = 2000,
                    payment_code = "Active"
                };

                var result = _unitOfWork.paymentRepository.CreatePayment(payment);
            }
        }
    }
}
