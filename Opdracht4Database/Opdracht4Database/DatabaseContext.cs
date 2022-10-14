using Microsoft.EntityFrameworkCore; 
namespace Database; 

public class DatabaseContext : DbContext
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer("Data Source=BEEST\\SQLEXPRESS;Initial Catalog=YourDatabase;Trusted_Connection=True;").EnableSensitiveDataLogging(true);
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Onderhoud> Onderhoud { get; set; }
    public DbSet<Gast> Gasten { get; set; }
    public DbSet<Attractie> Attracties { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }
    

    public async Task<bool> boek(Gast g, Attractie a, DateTimeBereik d)
    {
        bool succes = false;

        if(await a.vrij(this, d))
        {
            await a.Semaphore.WaitAsync();
            try 
            { 
                var transaction = this.Database.BeginTransaction();
                try
                {
                    transaction.CreateSavepoint("BeforeChanges");

                    await this.Reserveringen.AddAsync(new Reservering{ gast = g, dateTimeBereik = d, attractie = a});
                    await this.SaveChangesAsync(); 

                    g.credits--;
                    var gastToUpdate = await Task.Run(() => this.Gasten.Where(ga => ga.Id == g.Id));
                    
                    if(gastToUpdate != null)
                    {
                        this.Entry(gastToUpdate).CurrentValues.SetValues(g);
                    }
                    await this.SaveChangesAsync();

                    transaction.Commit();
                    succes = true;
                }
                catch (Exception e)
                {
                    transaction.RollbackToSavepoint("BeforeChanges");
                    Console.WriteLine("{0} Exception caught.", e);
                    succes = false;
                }
            }
            finally 
            { 
                a.Semaphore.Release();
            }
        }
        return succes;
    }



    protected override void OnModelCreating(ModelBuilder builder)
    {
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
            .OwnsOne(oh => oh.dateTimeBereik);
            
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
            .HasForeignKey<GastInfo>(ga => ga.gastForeignKey);

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
            .OwnsOne(gi => gi.coordinaat);

        builder.Entity<GastInfo>()
            .HasOne(gi => gi.gast)
            .WithOne(ga => ga.gastInfo);

        // Reservering
        //
        builder.Entity<Reservering>()
            .OwnsOne(re => re.dateTimeBereik);

        builder.Entity<Reservering>()
            .HasOne(re => re.gast)
            .WithMany(ga => ga.reserveringen);

        builder.Entity<Reservering>()
            .HasOne(re => re.attractie)
            .WithMany(at => at.reserveringen);
    }
}