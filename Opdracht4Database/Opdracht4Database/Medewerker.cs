using System.ComponentModel.DataAnnotations;
namespace Database;

public class Medewerker : Gebruiker
{
    public Medewerker(string email) : base(email) => base.email = email;
    // relationships
    public List<Onderhoud> coordineerd { get; set; }

    public List<Onderhoud> onderhoudt { get; set; }
}