using System.ComponentModel.DataAnnotations;
namespace Database;

public class Medewerker : Gebruiker
{
    // properties
    protected Medewerker() { Email = null!; }
    public Medewerker(string _email)
    {
        Email = _email;
    }

    // relationships
}