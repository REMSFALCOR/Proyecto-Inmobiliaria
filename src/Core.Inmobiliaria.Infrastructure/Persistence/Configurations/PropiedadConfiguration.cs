using Core.Inmobiliaria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Inmobiliaria.Infrastructure.Persistence.Configurations
{
    public class PropiedadConfiguration : IEntityTypeConfiguration<Propiedad>
    {
        public void Configure(EntityTypeBuilder<Propiedad> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodigoInterno)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Direccion)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Precio)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.SucursalId)
                .IsRequired();
        }
    }
}