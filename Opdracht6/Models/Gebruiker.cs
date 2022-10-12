using Microsoft.AspNetCore.Identity;
public class Gebruiker : IdentityUser
{
    public string? Password { get; init; }
    public string Geslacht { get; set; }
    public List<Attractie> gelikedeAttracties { get; set; } = new List<Attractie>();
}