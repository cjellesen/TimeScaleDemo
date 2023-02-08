using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SensorCollectionConfiguration : IEntityTypeConfiguration<SensorCollection>
{
    public void Configure(EntityTypeBuilder<SensorCollection> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityAlwaysColumn();
        builder.Property(e => e.Name).HasMaxLength(255).IsRequired();
    }
}