using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) => Database.EnsureCreated();

    public DbSet<Student> Students { get; set; }
    public DbSet<Teather> Teathers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Post> Posts { get; set; }
}
