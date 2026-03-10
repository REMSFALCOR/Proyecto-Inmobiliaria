using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Inmobiliaria.Infrastructure.Persistence;
using Core.Inmobiliaria.Application.Interfaces;
using Core.Inmobiliaria.Infrastructure.Repositories;

namespace Core.Inmobiliaria.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Registrar DbContext
        services.AddDbContext<InmobiliariaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Registrar repositorios
        services.AddScoped<IPropiedadRepository, PropiedadRepository>();

        // Registrar otros servicios de infraestructura si los tienes
        // services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}


/*
using Core.Inmobiliaria.Application.Interfaces;
using Core.Inmobiliaria.Infrastructure.Repositories;
using Core.Inmobiliaria.Infrastructure.DomainEventHandlers;
using Core.Inmobiliaria.EventBus;
using Core.Inmobiliaria.EventBusRabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;   // ← ESTE ES EL QUE FALTABA


namespace Core.Inmobiliaria.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        //public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Repositorios
            services.AddScoped<IPropiedadRepository, PropiedadRepository>();
            // EventBus
            services.AddSingleton<IEventBus, RabbitMQEventBus>();
            // Domain Event Handlers
            services.AddScoped<PropiedadCreadaDomainEventHandler>();

            return services;
        }
    }
}
*/