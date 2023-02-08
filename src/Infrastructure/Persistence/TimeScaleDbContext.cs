using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TimeScaleDbContext : DbContext, ITimeScaleDbContext
{
    public DbSet<SensorCollection> SensorCollections { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public TimeScaleDbContext(DbContextOptions<TimeScaleDbContext> options)
        : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new MeasurementConfiguration());
        builder.ApplyConfiguration(new SensorConfiguration());
        builder.ApplyConfiguration(new SensorCollectionConfiguration());
    }
}