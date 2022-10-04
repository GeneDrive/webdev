using System.ComponentModel.DataAnnotations;
namespace Database;

public class Medewerker : Gebruiker
{
    // properties
    protected Medewerker() { email = null!; }
    public Medewerker(string _email)
    {
        email = _email;
    }

    // relationships
    public List<Onderhoud> coordineerd { get; set; }

    public List<Onderhoud> onderhoudt { get; set; }
}