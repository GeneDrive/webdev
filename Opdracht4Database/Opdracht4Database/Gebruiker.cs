using System.ComponentModel.DataAnnotations;
namespace Database;

public class Gebruiker
{
    // properties
    public int ID { get; set;}
    public string email { get; set; }
    public Gebruiker(string email)
    {
        this.email = email;
    }
    
}