using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.ORM;

public class DataBaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=School.db");
        base.OnConfiguring(optionsBuilder);
    }
    
    public DbSet<Teacher> Teacher { get; set; } 
    public DbSet<Student> Student { get; set; }
    public DbSet<Grade> Grade { get; set; }
}