using Domain.Enums;

namespace Domain.Entities;

public class UnitTransformation
{
    public UnitOfMeasure MainUnit { get; set; }
    public UnitOfMeasure DerivedUnit { get; set; }
    public double Transformation { get; set; }
}