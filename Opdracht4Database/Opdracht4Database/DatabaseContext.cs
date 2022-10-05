using Microsoft.EntityFrameworkCore; 
namespace Database; 

public class DatabaseContext : DbContext
{
    public async Task<bool> boek(Gast g, Attractie a, DateTimeBereik d)
    {
        ////////////////////////
        //
        //// Logica hier
        //
        ////////////////////////

        // Temp
        return true;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=BEEST\\SQLEXPRESS;Initial Catalog=YourDatabase;Integrated Security=true");
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Onderhoud> Onderhoud { get; set; }
    public DbSet<Gast> Gasten { get; set; }
    public DbSet<Attractie> Attracties { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Gebruiker
        //
        builder.Entity<Gebruiker>()
            .ToTable("Gebruikers");

        builder.Entity<Gebruiker>()
            .HasKey(ge => ge.ID);

        // Medewerkers
        //
        builder.Entity<Medewerker>()
            .ToTable("Medewerkers");

        builder.Entity<Medewerker>()
            .HasMany(mw => mw.onderhoudt)
            .WithMany(oh => oh.onderhouders)
            .UsingEntity("Medewerker_Onderhouden");

        builder.Entity<Medewerker>()
            .HasMany(mw => mw.coordineerd)
            .WithMany(oh => oh.coordinatoren)
            .UsingEntity("Medewerker_Coordineert");

        // Onderhoud
        //
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
            .HasOne(g => g.begeleidt);

        builder.Entity<Gast>()
            .HasOne(ga => ga.favoriet)
            .WithMany(at => at.favorieten);

        builder.Entity<Gast>()
            .HasMany(ga => ga.reserveringen)
            .WithOne(re => re.gast)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Gast>()
            .HasOne(ga => ga.gastInfo)
            .WithOne(gi => gi.gast)
            .HasForeignKey<Gast>(ga => ga.ID);

        // Attractie
        //
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
            .OwnsOne(typeof(Coordinaat), "coordinaat");

        builder.Entity<GastInfo>()
            .HasOne(gi => gi.gast)
            .WithOne(ga => ga.gastInfo);

        // Reservering
        //
        builder.Entity<Reservering>()
            .OwnsOne(typeof(DateTimeBereik), "dateTimeBereik");

        builder.Entity<Reservering>()
            .HasOne(re => re.attractie)
            .WithMany(at => at.reserveringen);
    }
}