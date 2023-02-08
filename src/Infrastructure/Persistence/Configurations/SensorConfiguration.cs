using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
{
    public void Configure(EntityTypeBuilder<Sensor> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(255).IsRequired();
        builder.Property(e => e.Id).UseIdentityAlwaysColumn();
        builder.Property(e => e.UnitOfMeasure).IsRequired();
        builder.HasMany(e => e.Measurements).WithOne().HasPrincipalKey(e => e.Id).HasForeignKey(e => e.Id);
    }
}