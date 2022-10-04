using Microsoft.EntityFrameworkCore; 
namespace Database;

public class DatabaseContext : DbContext
{
    public DbSet<Gebruiker> Gebruikers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Medewerker>().ToTable("Medewerkers");

        builder.Entity<Gast>().ToTable("Gasten");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=BEEST\\SQLEXPRESS;Initial Catalog=YourDatabase;Integrated Security=true");
    
}