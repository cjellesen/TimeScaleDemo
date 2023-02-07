using Domain.Common;

namespace Domain.Entities;

public class SensorCollection : AbstractSensor
{
    public List<Sensor> Sensors { get; set; } = new();

    internal SensorCollection(string name, string description) : base(name, description)
    { }
}