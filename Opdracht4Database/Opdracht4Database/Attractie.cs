using System.ComponentModel.DataAnnotations;
namespace Database;

public class Attractie
{
    // properties
    public int Id { get; set; }
    public string naam { get; set; }

    protected Attractie() { naam = null!; }
    public Attractie(string _naam)
    {
        naam = _naam;
    }
    public async Task<bool> onderhoudBezig(DatabaseContext c)
    {
        ////////////////////////
        //
        //// Logica hier
        //
        ////////////////////////

        // Temp
        return true;
    }

    public async Task<bool> vrij(DatabaseContext c, DateTimeBereik d)
    {
        ////////////////////////
        //
        //// Logica hier
        //
        ////////////////////////

        // Temp
        return true;
    }

    // relationships
    public List<Reservering> reserveringen { get; set; }
    public List<Gast> favorieten { get; set; }
    public List<Onderhoud> onderhouds { get; set; }

}