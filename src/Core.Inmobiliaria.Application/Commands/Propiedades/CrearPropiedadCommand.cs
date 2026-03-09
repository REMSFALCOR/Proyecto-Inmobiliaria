using MediatR;

namespace Core.Inmobiliaria.Application.Commands.Propiedades
{
public record CrearPropiedadCommand(
    string CodigoInterno,
    string Direccion,
    decimal Precio,
    Guid SucursalId
) : IRequest<Guid>;
}