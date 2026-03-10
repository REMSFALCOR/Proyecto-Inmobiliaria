using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Inmobiliaria.EventBus;

namespace Core.Inmobiliaria.EventBusRabbitMQ
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IEventBus>(sp =>
                new RabbitMQEventBus(config, sp)
            );

            return services;
        }
    }
}
