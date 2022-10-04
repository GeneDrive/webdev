using System.ComponentModel.DataAnnotations;
namespace Database;

public class Gebruiker
{
    // properties
    [Key]
    public int ID { get; set;}
    public string email { get; set; }
    protected Gebruiker() { email = null!; }
    public Gebruiker(string _email)
    {
        email = _email;
    }
}