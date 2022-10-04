using System.ComponentModel.DataAnnotations;
namespace Database;

public class Gast : Gebruiker
{
    // properties
    public int credits { get; set; }
    public DateTime geboorteDatum { get; set; }
    public DateTime eersteBezoek { get; set; }
    protected Gast() { email = null!; }
    public Gast(string _email)
    {
        email = _email;
    }

    // relationships
    public Gast? begeleidt { get; set; }
    public Attractie? favoriet { get; set; }
    public List<Reservering> reserveringen { get; set; }
    // OWNED
    public GastInfo gastInfo { get; set; }
}