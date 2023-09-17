namespace Domain;
public abstract class BaseTeacherDto
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Position { get; set; }
    public byte? Experiens { get; set; } = null;
}
