using Core.Inmobiliaria.Application.Interfaces;
using Core.Inmobiliaria.Domain.Entities;
using Core.Inmobiliaria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Core.Inmobiliaria.Infrastructure.Repositories
{
    public class PropiedadRepository : IPropiedadRepository
    {
        private readonly InmobiliariaDbContext _context;
        public PropiedadRepository(InmobiliariaDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Propiedad propiedad)
        {
            await _context.Propiedades.AddAsync(propiedad);
        }
        public async Task<Propiedad?> GetByIdAsync(Guid id)
        {
            return await _context.Propiedades.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}