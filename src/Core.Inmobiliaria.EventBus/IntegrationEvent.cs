using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Inmobiliaria.EventBus;

namespace Core.Inmobiliaria.EventBus
{
    public abstract class IntegrationEvent
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}