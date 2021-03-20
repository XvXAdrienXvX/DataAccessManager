using DataAccessManager.Repository;
using DataAccessManager.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessManager
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(DataAccessManager.UnitOfWork.UnitOfWork));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(ISQLUtility), typeof(SQLUtility));

            return services;
        }
    }
}
