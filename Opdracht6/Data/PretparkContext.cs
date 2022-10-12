using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class PretparkContext : IdentityDbContext
{
    public PretparkContext (DbContextOptions<PretparkContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Gebruiker>()
            .HasMany(gb => gb.gelikedeAttracties)
            .WithMany(at => at.gebruikerLikes)
            .UsingEntity("gb_at-Likes");

        builder.Entity<Attractie>()
            .HasMany(at => at.gebruikerLikes)
            .WithMany(gb => gb.gelikedeAttracties);
            
    }
    public DbSet<Attractie> Attractie { get; set; } = default!;
    public DbSet<Gebruiker> Gebruiker { get; set; } = default!;
}
