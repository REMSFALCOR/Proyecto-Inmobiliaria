using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Inmobiliaria.EventBus
{
    public interface IIntegrationEventHandler<in TEvent>
        where TEvent : IntegrationEvent
    {
        Task Handle(TEvent @event);
    }
}