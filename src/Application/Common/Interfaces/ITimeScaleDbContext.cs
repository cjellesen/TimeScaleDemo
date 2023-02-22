using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface ITimeScaleDbContext
{
    public DbSet<SensorCollection> SensorCollections { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<UnitTransformation> UnitTransformations { get; set; }

    public abstract Task<IEnumerable<Sensor>> GetAllSensors();
    public abstract Task<IEnumerable<Measurement>> GetAllMeasurements(Sensor sensor);
    public abstract Task<IEnumerable<Measurement>> GetAllMeasurements(Sensor sensor, DateTime from, DateTime to);
}