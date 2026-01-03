using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Models;

namespace ConsoleApp1;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Staff> Staff => Set<Staff>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
                "Server=localhost;Database=SchoolSystem;User Id=sa;Password=Teda1384;TrustServerCertificate=True;"
            );
    }
    
}
