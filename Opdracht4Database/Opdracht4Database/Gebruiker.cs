using System.ComponentModel.DataAnnotations;
namespace Database;

public class Gebruiker
{
    [Key]
    public int ID { get; set;}
    public string Email { get; set; }

    protected Gebruiker() { Email = null!; }
    public Gebruiker(string _email)
    {
        Email = _email;
    }
}