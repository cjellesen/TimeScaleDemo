namespace Domain.Common;

public abstract class AbstractSensor : AbstractEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    
    private protected AbstractSensor(string name, string description)
    {
        Name = name;
        Description = description;
        CreatedAt = DateTime.Now;
        LastUpdatedAt = DateTime.Now;
    }
}