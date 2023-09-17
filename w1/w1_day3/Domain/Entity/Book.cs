using System.ComponentModel.DataAnnotations;
namespace Domain;

public class Book
{
    [Key]
    public int Id { get; set; }
    [MaxLength(30)]
    public string Title { get; set; }
    [MaxLength(30)]
    public string Author { get; set; }
    [MaxLength(100)]
    public string? FileName { get; set; }
}
