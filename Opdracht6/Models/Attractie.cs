public class Attractie
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Engheid { get; set; }
    public int Bouwjaar { get; set; }
    public List<Gebruiker> gebruikerLikes { get; set; } = new List<Gebruiker>();
    public int aantalLikes 
    { 
        get
        {
            return gebruikerLikes.Count();
        }
        set {}
    }
}