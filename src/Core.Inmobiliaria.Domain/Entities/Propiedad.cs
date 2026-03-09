using Core.Inmobiliaria.Domain.Common;
using Core.Inmobiliaria.Domain.Events;

namespace Core.Inmobiliaria.Domain.Entities
{
public class Propiedad : BaseEntity
{
     public Guid Id { get; private set; } = Guid.NewGuid();
    public string CodigoInterno { get; private set; }
    public string Direccion { get; private set; }
    public decimal Precio { get; private set; }
    public Guid SucursalId { get; private set; }



    public Propiedad(string codigoInterno, string direccion, decimal precio, Guid sucursalId)
    {
        CodigoInterno = codigoInterno;
        Direccion = direccion;
        Precio = precio;
        SucursalId = sucursalId;

        AddDomainEvent(new PropiedadCreadaDomainEvent(
            Id,
            CodigoInterno,
            Precio
        ));
    }
    public void CambiarPrecio(decimal nuevoPrecio)
    {
        Precio = nuevoPrecio;
    }
}
}