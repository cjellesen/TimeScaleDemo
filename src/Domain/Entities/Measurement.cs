using Domain.Common;

namespace Domain.Entities;

public class Measurement : AbstractEntity
{
    public DateTime Time { get; private set; }
    public double Value { get; private set; }

    public Measurement(DateTime time, double value)
    {
        Time = time;
        Value = value;
    }
}