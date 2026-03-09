//using Core.Inmobiliaria.Worker;
using Core.Inmobiliaria.EventBus;
using Core.Inmobiliaria.EventBusRabbitMQ;
using Core.Inmobiliaria.Infrastructure.IntegrationEvents;
using Core.Inmobiliaria.Worker.IntegrationEventHandlers;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();
builder.Services.AddTransient<PropiedadCreadaIntegrationEventHandler>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

var eventBus = host.Services.GetRequiredService<IEventBus>();

eventBus.Subscribe<PropiedadCreadaIntegrationEvent, PropiedadCreadaIntegrationEventHandler>();

host.Run();
