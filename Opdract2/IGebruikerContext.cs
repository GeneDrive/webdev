namespace Authenticatie
{
    public interface IGebruikerContext
    {
        public int AantalGebruikers();
        public Gebruiker GetGebruiker(int i);
        public Gebruiker NieuweGebruiker(string wachtwoord, string email);
    }
}