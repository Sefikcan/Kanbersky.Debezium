using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Mappings.AutoMapper;
using System.Reflection;

namespace Payment.Application.Extensions
{
    public static class PaymentServiceExtensions
    {
        public static IServiceCollection RegisterPaymentServiceLayer(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
