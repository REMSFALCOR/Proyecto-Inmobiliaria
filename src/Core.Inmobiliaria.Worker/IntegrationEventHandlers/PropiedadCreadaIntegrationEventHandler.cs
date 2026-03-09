using Core.Inmobiliaria.EventBus;
using Core.Inmobiliaria.Infrastructure.IntegrationEvents;

namespace Core.Inmobiliaria.Worker.IntegrationEventHandlers
{
    public class PropiedadCreadaIntegrationEventHandler 
        : IIntegrationEventHandler<PropiedadCreadaIntegrationEvent>
    {
        public Task Handle(PropiedadCreadaIntegrationEvent @event)
        {
            Console.WriteLine("📩 Evento recibido en Worker:");
            Console.WriteLine($"Propiedad creada: {@event.PropiedadId}");
            Console.WriteLine($"Código: {@event.CodigoInterno}");
            Console.WriteLine($"Precio: {@event.Precio}");

            // Aquí puedes hacer lo que quieras:
            // - Enviar email
            // - Actualizar otro microservicio
            // - Registrar logs
            // - Llamar APIs externas

            return Task.CompletedTask;
        }
    }
}