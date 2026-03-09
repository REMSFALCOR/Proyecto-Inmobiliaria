using Core.Inmobiliaria.Domain.Events;
using Core.Inmobiliaria.EventBus;
using Core.Inmobiliaria.Infrastructure.IntegrationEvents;

using MediatR;

namespace Core.Inmobiliaria.Infrastructure.DomainEventHandlers
{
    public class PropiedadCreadaDomainEventHandler 
        : INotificationHandler<PropiedadCreadaDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public PropiedadCreadaDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(PropiedadCreadaDomainEvent notification, CancellationToken cancellationToken)
        {
            // Publicar V1
            var v1 = new PropiedadCreadaIntegrationEventV1(
                notification.PropiedadId,
                notification.CodigoInterno,
                notification.Precio
            );

            _eventBus.Publish(v1);

            // Publicar V2
            var v2 = new PropiedadCreadaIntegrationEventV2(
                notification.PropiedadId,
                notification.CodigoInterno,
                notification.Precio,
                DateTime.UtcNow,
                "admin"
            );

            _eventBus.Publish(v2);

            return Task.CompletedTask;
        }
    }
}