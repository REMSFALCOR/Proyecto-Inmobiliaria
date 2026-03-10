using Core.Inmobiliaria.EventBus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Inmobiliaria.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQEventBus(IConfiguration config, IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        var connectionString = config["RabbitMQ:ConnectionString"];

        var factory = new ConnectionFactory()
        {
            Uri = new Uri(connectionString)
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Publish(IntegrationEvent @event)
    {
        var eventName = @event.GetType().Name;

        _channel.QueueDeclare(
            queue: eventName,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event));

        _channel.BasicPublish(
            exchange: "",
            routingKey: eventName,
            basicProperties: null,
            body: body
        );
    }

    public void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>
    {
        var eventName = typeof(T).Name;

        _channel.QueueDeclare(
            queue: eventName,
            durable: true,
            exclusive: false,
            autoDelete: false
        );

        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var integrationEvent = JsonSerializer.Deserialize<T>(message);

            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<TH>();

            await handler.Handle(integrationEvent);
        };

        _channel.BasicConsume(
            queue: eventName,
            autoAck: true,
            consumer: consumer
        );
    }
}


/*using Core.Inmobiliaria.EventBus;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Core.Inmobiliaria.EventBusRabbitMQ;

public class RabbitMQEventBus : IEventBus
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQEventBus(IConfiguration config)//IConfiguration config
    {
    /*
        var host = config["RabbitMQ:Host"];
        var user = config["RabbitMQ:User"];
        var pass = config["RabbitMQ:Password"];

    var factory = new ConnectionFactory()
    {
        Uri = new Uri($"amqp://{user}:{pass}@{host}:5672/")
    };
    */
/*    
        // Leer la cadena AMQP desde appsettings.json
        var connectionString = config["RabbitMQ:ConnectionString"];
        // Crear la fábrica usando la URI completa
        var factory = new ConnectionFactory()
        {
            //HostName = "localhost",// UsuarioDto
            //UserName = "guest",
            //Password = "guest"
            Uri = new Uri(connectionString)
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
*/
/*
"RabbitMQ": { 
    "ConnectionString": "amqp://admin:Rems101275@localhost:5672"
  },
 
 o 

"RabbitMQ": {
  "Host": "localhost",
  "User": "guest",
  "Password": "guest"
},


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