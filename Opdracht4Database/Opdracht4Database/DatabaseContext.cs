using Microsoft.EntityFrameworkCore; 
namespace Database; 

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=BEEST\\SQLEXPRESS;Initial Catalog=YourDatabase;Integrated Security=true");
    
    public DbSet<Gebruiker> Gebruikers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Medewerkers
        //
        builder.Entity<Medewerker>()
            .ToTable("Medewerkers");

        builder.Entity<Medewerker>()
            .HasMany(mw => mw.onderhoudt)
            .WithMany(oh => oh.onderhouders);

        builder.Entity<Medewerker>()
            .HasMany(mw => mw.coordineerd)
            .WithMany(oh => oh.coordinatoren);

        // Onderhoud
        //
        builder.Entity<Onderhoud>()
            .ToTable("Onderhoud");

        builder.Entity<Onderhoud>()
            .HasMany(oh => oh.coordinatoren)
            .WithMany(mw => mw.coordineerd);

        builder.Entity<Onderhoud>()
            .HasMany(oh => oh.onderhouders)
            .WithMany(mw => mw.onderhoudt);

        builder.Entity<Onderhoud>()
            .HasOne(oh => oh.attractie)
            .WithMany(at => at.onderhouds);

        builder.Entity<Onderhoud>()
            .OwnsOne(typeof(DateTimeBereik), "dateTimeBereik");
            
        // Gast
        //
        builder.Entity<Gast>()
            .ToTable("Gasten");

        builder.Entity<Gast>()
            .HasOne(g => g.begeleidt)
            .WithOne(g2 => g2);

        builder.Entity<Gast>()
            .HasOne(ga => ga.favoriet)
            .WithMany(at => at.favorieten);

        builder.Entity<Gast>()
            .HasMany(ga => ga.reserveringen)
            .WithOne(re => re.gast);

        builder.Entity<Gast>()
            .OwnsOne(typeof(GastInfo), "gastInfo");

        // Attractie
        //
        builder.Entity<Attractie>()
            .ToTable("Attractie");

        builder.Entity<Attractie>()
            .HasMany(at => at.reserveringen)
            .WithOne(re => re.attractie);

        builder.Entity<Attractie>()
            .HasMany(at => at.favorieten)
            .WithOne(ga => ga.favoriet);

        builder.Entity<Attractie>()
            .HasMany(at => at.onderhouds)
            .WithOne(oh => oh.attractie);

        // GastInfo
        //
        builder.Entity<GastInfo>()
            .ToTable("GastInfo");

        builder.Entity<GastInfo>()
            .OwnsOne(typeof(Coordinaat), "coordinaat");

        builder.Entity<GastInfo>()
            .HasOne(gi => gi.gast)
            .WithOne(ga => ga.gastInfo);

        // Reservering
        //
        builder.Entity<Reservering>()
            .ToTable("Reservering");

        builder.Entity<Reservering>()
            .OwnsOne(typeof(DateTimeBereik), "dateTimeBereik");

        builder.Entity<Reservering>()
            .HasOne(re => re.attractie)
            .WithMany(at => at.reserveringen);
    }
}