using System.ComponentModel.DataAnnotations;
namespace Database;

public class Attractie
{
    // properties
    [Key]
    public int ID { get; set;}
    public string Naam { get; set;}
    public async Task<bool> OnderhoudBezig(DatabaseContext c)
    {
        ////////////////////////
        //
        //// Logica hier
        //
        ////////////////////////

        // Temp
        return true;
    }

    public async Task<bool> Vrij(DatabaseContext c, DateTimeBereik d)
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
}