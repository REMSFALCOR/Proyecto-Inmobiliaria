using Core.Inmobiliaria.Application.Interfaces;
using Core.Inmobiliaria.Domain.Entities;
using Core.Inmobiliaria.Domain.Events;
using MediatR;

namespace Core.Inmobiliaria.Application.Commands.Propiedades;

public class CrearPropiedadCommandHandler : IRequestHandler<CrearPropiedadCommand, Guid>
{
    private readonly IPropiedadRepository _repo;

    public CrearPropiedadCommandHandler(IPropiedadRepository repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(CrearPropiedadCommand request, CancellationToken cancellationToken)
    {
        var propiedad = new Propiedad(
            request.CodigoInterno,
            request.Direccion,
            request.Precio,
            request.SucursalId
        );

        propiedad.AddDomainEvent(new PropiedadCreadaDomainEvent(
            propiedad.Id,
            propiedad.CodigoInterno,
            propiedad.Precio
        ));

        await _repo.AddAsync(propiedad);

        return propiedad.Id;
    }
}