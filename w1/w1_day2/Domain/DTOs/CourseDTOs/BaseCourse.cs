namespace Domain;
public abstract class BaseCourse
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Duration { get; set; }
    public DurationType DurationType { get; set; }
}
