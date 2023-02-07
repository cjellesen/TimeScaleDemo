using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class TimeScaleDbContext : DbContext, ITimeScaleDbContext
{
    public DbSet<SensorCollection> SensorCollections { get; set; }
    public DbSet<Sensor> Sensors { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    
    public TimeScaleDbContext(DbContextOptions<TimeScaleDbContext> options)
        : base(options)
    {
    }
}