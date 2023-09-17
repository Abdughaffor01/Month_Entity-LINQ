using System.ComponentModel.DataAnnotations;
namespace Domain;
public class Teather
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string Name { get; set; }
    [MaxLength(30)]
    public string SurName { get; set; }
    [MaxLength(30)]
    public string Position { get; set; }
    public byte? Experiens { get; set; } = null;
}
