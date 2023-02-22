using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class TimeScaleDbContext : DbContext, ITimeScaleDbContext
{
    public readonly string SchemaName = "TimeScale";
    
    public virtual DbSet<SensorCollection> SensorCollections { get; set; }
    public virtual DbSet<Sensor> Sensors { get; set; }
    public virtual DbSet<Measurement> Measurements { get; set; }
    public virtual DbSet<UnitTransformation> UnitTransformations { get; set; }
    
    public TimeScaleDbContext()
        : base(GetNpSqlOptions(""))
    { }
    
    public TimeScaleDbContext(DbContextOptions<TimeScaleDbContext> options)
        : base(options)
    { }

    public async Task<IEnumerable<Sensor>> GetAllSensors()
    {
        return await Sensors.ToListAsync();
    }

    public async Task<IEnumerable<Measurement>> GetAllMeasurements(Sensor sensor)
    {
        return await Measurements.Where(e => e.Id == sensor.Id).ToListAsync();
    }

    public async Task<IEnumerable<Measurement>> GetAllMeasurements(Sensor sensor, DateTime from, DateTime to)
    {
        return await Measurements.Where(e => e.Id == sensor.Id && e.Time >= from && e.Time < to).ToListAsync();
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