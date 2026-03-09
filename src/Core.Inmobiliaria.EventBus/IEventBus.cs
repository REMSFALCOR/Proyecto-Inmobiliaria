using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Inmobiliaria.EventBus
{
public interface IEventBus
{
    void Publish(IntegrationEvent @event);
    void Subscribe<T, TH>()
        where T : IntegrationEvent
        where TH : IIntegrationEventHandler<T>;
}
}