using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Common.Settings;
using Payment.Infrastructure.DataContext;

namespace Payment.Infrastructure.Extensions
{
    public static class PaymentInfrastructureExtensions
    {
        public static IServiceCollection RegisterInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            PaymentDbSettings paymentDbSettings = new PaymentDbSettings();
            configuration.GetSection(nameof(PaymentDbSettings)).Bind(paymentDbSettings);
            services.AddSingleton(paymentDbSettings);

            services.AddDbContext<PaymentDbContext>(c =>
                c.UseSqlServer(paymentDbSettings.ConnectionStrings), ServiceLifetime.Transient);

            return services;
        }
    }
}
