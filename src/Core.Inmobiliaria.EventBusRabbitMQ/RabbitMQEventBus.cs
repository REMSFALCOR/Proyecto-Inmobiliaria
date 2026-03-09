using Core.Inmobiliaria.EventBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
//using Microsoft.Extensions.Configuration;

namespace Core.Inmobiliaria.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQEventBus()//IConfiguration config
    {
        // Leer la cadena AMQP desde appsettings.json
        //var connectionString = config["RabbitMQ:ConnectionString"];

        // Crear la fábrica usando la URI completa
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",// UsuarioDto
            UserName = "guest",
            Password = "guest"
            //Uri = new Uri(connectionString)
        };

        // Crear conexión y canal
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Publish(IntegrationEvent @event)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));

        // Publicación simple usando el nombre del evento como routing key
        _channel.BasicPublish(
            exchange: "",
            routingKey: @event.GetType().Name,
            basicProperties: null,
            body: body
        );
    }

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        // Implementación opcional
    }
}
/*
using Core.Inmobiliaria.EventBus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration; // ← este sí es válido


namespace Core.Inmobiliaria.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQEventBus()
    {
        var connectionString = config["RabbitMQ:ConnectionString"];
        var factory = new ConnectionFactory
        {
            HostName = new Uri(connectionString)//"localhost"
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Publish(IntegrationEvent @event)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));

        _channel.BasicPublish(
            exchange: "",
            routingKey: @event.GetType().Name,
            basicProperties: null,
            body: body
        );
    }

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        // Implementación opcional
    }
}
*/