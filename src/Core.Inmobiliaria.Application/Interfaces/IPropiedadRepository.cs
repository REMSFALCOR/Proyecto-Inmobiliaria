using Core.Inmobiliaria.Domain.Entities;

namespace Core.Inmobiliaria.Application.Interfaces
{
    public interface IPropiedadRepository
    {
        Task AddAsync(Propiedad propiedad);
        Task<Propiedad?> GetByIdAsync(Guid id);
    }
}