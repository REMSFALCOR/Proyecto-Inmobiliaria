using Core.Inmobiliaria.EventBus;

namespace Core.Inmobiliaria.Infrastructure.IntegrationEvents
{
    public class PropiedadCreadaIntegrationEvent : IntegrationEvent
    {
        public Guid PropiedadId { get; }
        public string CodigoInterno { get; }
        public decimal Precio { get; }

        public PropiedadCreadaIntegrationEvent(Guid propiedadId, string codigoInterno, decimal precio)
        {
            PropiedadId = propiedadId;
            CodigoInterno = codigoInterno;
            Precio = precio;
        }
    }
}