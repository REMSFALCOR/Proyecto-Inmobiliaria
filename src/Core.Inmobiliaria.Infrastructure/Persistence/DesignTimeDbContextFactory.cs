using Core.Inmobiliaria.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core.Inmobiliaria.Infrastructure.Persistence
{
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InmobiliariaDbContext>
{
    public InmobiliariaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InmobiliariaDbContext>();

        // Cadena de conexión SOLO para migraciones
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=InmobiliariaDb;User Id=sa;Password=Rems101275;TrustServerCertificate=True;"
        );

        return new InmobiliariaDbContext(optionsBuilder.Options);
    }
}
}