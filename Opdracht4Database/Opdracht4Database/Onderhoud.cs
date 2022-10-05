using System.ComponentModel.DataAnnotations;
namespace Database;

public class Onderhoud
{
    // properties
    public int Id { get; set; }
    
    public string probleem { get; set; }

    // relationships
    public List<Medewerker> coordinatoren { get; set; }

    public List<Medewerker> onderhouders { get; set; }

    public Attractie attractie { get; set; }

    // OWNED
    public DateTimeBereik dateTimeBereik { get; set; }
}
