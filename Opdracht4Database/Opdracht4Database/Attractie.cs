using System.ComponentModel.DataAnnotations;
namespace Database;

public class Attractie
{
    // properties
    [Key]
    public int ID { get; set; }
    public string naam { get; set; }
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