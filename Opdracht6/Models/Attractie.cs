public class Attractie
{
    public int Id { get; set; }
    public string Naam { get; set; }
    public string Engheid { get; set; }
    public int Bouwjaar { get; set; }
    public List<Gebruiker>? gebruikerLikes { get; set; }
    public int? aantalLikes 
    { 
        get
        {
            if(gebruikerLikes == null)
                return 0;

            return gebruikerLikes.Count();
        }
        set {}
    }
}