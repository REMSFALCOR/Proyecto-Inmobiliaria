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

/*
using Core.Inmobiliaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Inmobiliaria.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Inmobiliaria.Infrastructure.Persistence
{
public class InmobiliariaDbContext : DbContext
{
    private readonly IMediator _mediator;
    public InmobiliariaDbContext(DbContextOptions<InmobiliariaDbContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    public InmobiliariaDbContext(DbContextOptions<InmobiliariaDbContext> options) : base(options)
    {
    }

    public DbSet<Propiedad> Propiedades => Set<Propiedad>();
    public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Guardar cambios
        var result = await base.SaveChangesAsync(cancellationToken);

        // Publicar eventos de dominio
        await DispatchDomainEvents();

        return result;
    }

    private async Task DispatchDomainEvents()
    {
        var entities = ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        foreach (var entity in entities)
        {
            var events = entity.DomainEvents.ToList();
            entity.ClearDomainEvents();

            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }


}
}
*/