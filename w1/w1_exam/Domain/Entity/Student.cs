using System.ComponentModel.DataAnnotations;
namespace Domain.Entity;
public class Student
{
    public int Id { get; set; }
    [MaxLength(30)]
    public string FirstName { get; set; }
    [MaxLength(30)]
    public string LastName { get; set; }
    [MaxLength(30)]
    public string FatherName { get; set; }
    public DateTime? BirthDate { get; set; }
    [MaxLength(30)]
    public string Address { get; set; }
    [MaxLength(13)]
    public string Phone { get; set; }
}
