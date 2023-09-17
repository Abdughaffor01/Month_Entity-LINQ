namespace Domain;
public class GetBookDto : BaseBookDto
{
    public int Id { get; set; }
    public string? FileName { get; set; }
}
