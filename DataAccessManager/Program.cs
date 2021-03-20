using DataAccessManager.Entites;
using DataAccessManager.Repository;
using DataAccessManager.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessManager
{
    partial class Program
    {
        private static IServiceProvider _serviceProvider;


        static void Main(string[] args)
        {
            //IDbConnection connection = ConnectionManager.CreateConnection();
            //IDbTransaction transaction = connection.BeginTransaction();
            //var command = connection.CreateCommand();

            Payment payment = new Payment()
            {
                member_no = 84,
                payment_dt = DateTime.Now,
                payment_amt = 2000,
                statement_no = 0,
                payment_code = "A"
            };
    

            RegisterServices();
            var service = _serviceProvider.GetService<IUnitOfWork>();

            Task.Run(async () =>
            {           

                await service.paymentRepository.CreatePayment(payment);
                service.Commit();
            }).GetAwaiter().GetResult();
        }

        private async static void RunAsync()
        {

            Payment payment = new Payment()
            {
                member_no = 84,
                payment_dt = DateTime.Now,
                payment_amt = 2000,
                statement_no = 0,
                payment_code = "Active"
            };
            var service = _serviceProvider.GetService<IUnitOfWork>();

            await service.paymentRepository.CreatePayment(payment);
            service.Commit();
        }

        private static void RegisterServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient(typeof(IUnitOfWork), typeof(DataAccessManager.UnitOfWork.UnitOfWork));
            services.AddTransient(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddTransient(typeof(ISQLUtility), typeof(SQLUtility));

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
