using Microsoft.EntityFrameworkCore; 
namespace Database;

public class DatabaseContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=Beest\"SQLEXPRESS\"\"MSSQLLocalDB;Initial Catalog=YourDatabase;Integrated Security=true");
    
    public DbSet<Gebruiker> Gebruikers { get; set; }
}