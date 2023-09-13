namespace Domain;
public class GetQuoteDto:BaseQuoteDto
{
    public int Id { get; set; }
    public List<string>? Images { get; set; }
}
