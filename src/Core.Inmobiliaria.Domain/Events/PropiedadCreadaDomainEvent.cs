using MediatR;

namespace Core.Inmobiliaria.Domain.Events
{
    public class PropiedadCreadaDomainEvent : INotification
    {
        public Guid PropiedadId { get; }
        public string CodigoInterno { get; }
        public decimal Precio { get; }

        public PropiedadCreadaDomainEvent(Guid propiedadId, string codigoInterno, decimal precio)
        {
            PropiedadId = propiedadId;
            CodigoInterno = codigoInterno;
            Precio = precio;
        }
    }
}