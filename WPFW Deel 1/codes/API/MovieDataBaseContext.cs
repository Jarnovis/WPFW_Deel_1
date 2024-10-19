using Microsoft.EntityFrameworkCore;

namespace WPFW_Deel_1.codes.API;

public class MovieDataBaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MovieDataBase.db");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Movie> movies {get; set;}
    public DbSet<Review> reviews {get; set;}
    public DbSet<Director> directors {get; set;}
}