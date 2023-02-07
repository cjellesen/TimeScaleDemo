using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Measurement : AbstractEntity
{
    public DateTime Time { get; private set; }
    public double Value { get; private set; }
    public Quality Quality { get; private set; }

    public Measurement(DateTime time, double value, Quality quality)
    {
        Time = time;
        Value = value;
        Quality = quality;
    }
}