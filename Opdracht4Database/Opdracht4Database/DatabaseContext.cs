using Microsoft.EntityFrameworkCore; 
namespace Database;

public class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=BEEST\\SQLEXPRESS;Initial Catalog=YourDatabase;Integrated Security=true");
    
    public DbSet<Gebruiker> Gebruikers { get; set; }
}