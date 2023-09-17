namespace Domain;

public class GetPostDto : BasePostDto
{
    public int Id { get; set; }
    public int Vote { get; set; }
    public DateTime CreateAt { get; set; }
}
