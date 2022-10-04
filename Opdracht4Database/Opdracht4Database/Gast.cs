using System.ComponentModel.DataAnnotations;
namespace Database;

public class Gast : Gebruiker
{
    // properties
    public int Credits { get; set;}
    public DateTime GeboorteDatum { get; set;}
    public DateTime EersteBezoek { get; set;}
    protected Gast() { Email = null!; }
    public Gast(string _email)
    {
        Email = _email;
    }

    // relationships
    public Gast Begeleidt { get; set;}

    public GastInfo gastInfo { get; set;}
}