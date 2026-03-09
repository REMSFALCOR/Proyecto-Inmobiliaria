using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Inmobiliaria.Infrastructure.Persistence.Entities
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }
        public DateTime OccurredOn { get; set; }
        public string Type { get; set; } = default!;
        public string Payload { get; set; } = default!;
        public bool Processed { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}