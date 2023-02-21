using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TimeScaleDbContext : DbContext, ITimeScaleDbContext
{
    public virtual DbSet<SensorCollection> SensorCollections { get; set; }
    public virtual DbSet<Sensor> Sensors { get; set; }
    public virtual DbSet<Measurement> Measurements { get; set; }
    public readonly string SchemaName = "TimeScale";

    public TimeScaleDbContext()
        : base(GetNpSqlOptions(""))
    { }
    
    public TimeScaleDbContext(DbContextOptions<TimeScaleDbContext> options)
        : base(options)
    { }

    public async Task<IEnumerable<Sensor>> GetAllSensors()
    {
        return Sensors;
    }
    
    public static DbContextOptions GetNpSqlOptions(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder();
        optionsBuilder.UseNpgsql(connectionString);
        return optionsBuilder.Options;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasDefaultSchema(SchemaName);
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new MeasurementConfiguration());
        builder.ApplyConfiguration(new SensorConfiguration());
        builder.ApplyConfiguration(new SensorCollectionConfiguration());
    }
}