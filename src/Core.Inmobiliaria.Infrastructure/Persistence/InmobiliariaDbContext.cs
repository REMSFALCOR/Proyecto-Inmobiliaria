using Core.Inmobiliaria.Domain.Entities;
using Core.Inmobiliaria.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Inmobiliaria.Infrastructure.Persistence;

public class InmobiliariaDbContext : DbContext
{
    public InmobiliariaDbContext(DbContextOptions<InmobiliariaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Propiedad> Propiedades => Set<Propiedad>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
}
