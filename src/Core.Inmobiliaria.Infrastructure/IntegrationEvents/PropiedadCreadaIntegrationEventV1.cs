using Core.Inmobiliaria.EventBus;


namespace Core.Inmobiliaria.Infrastructure.IntegrationEvents
{
    public class PropiedadCreadaIntegrationEventV1 : IntegrationEvent
    {
        public Guid PropiedadId { get; }
        public string CodigoInterno { get; }
        public decimal Precio { get; }

        public PropiedadCreadaIntegrationEventV1(Guid propiedadId, string codigoInterno, decimal precio)
        {
            PropiedadId = propiedadId;
            CodigoInterno = codigoInterno;
            Precio = precio;
        }
    }
}