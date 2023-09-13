namespace Domain;
public class GetQuotesDto
{
    public List<QuoteIdByImagesDto>? Images { get; set; }
    public List<GetQuoteDto>? Quotes { get; set; }

}
