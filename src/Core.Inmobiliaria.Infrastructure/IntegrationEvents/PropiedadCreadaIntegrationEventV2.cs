using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Inmobiliaria.EventBus;

namespace Core.Inmobiliaria.Infrastructure.IntegrationEvents
{
    public class PropiedadCreadaIntegrationEventV2 : IntegrationEvent
    {
        public Guid PropiedadId { get; }
        public string CodigoInterno { get; }
        public decimal Precio { get; }
        public DateTime FechaCreacion { get; }
        public string UsuarioCreador { get; }

        public PropiedadCreadaIntegrationEventV2(
            Guid propiedadId,
            string codigoInterno,
            decimal precio,
            DateTime fechaCreacion,
            string usuarioCreador)
        {
            PropiedadId = propiedadId;
            CodigoInterno = codigoInterno;
            Precio = precio;
            FechaCreacion = fechaCreacion;
            UsuarioCreador = usuarioCreador;
        }
    }
}