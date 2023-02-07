using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Sensor : AbstractSensor
{
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public List<Measurement> Measurements { get; } = new();

    public Sensor(string name, string description, UnitOfMeasure unitOfMeasure) : base(name, description)
    {
        UnitOfMeasure = unitOfMeasure;
    }
}