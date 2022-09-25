namespace Authenticatie
{
    public interface IGebruikerContext
    {
        //private List<Gebruiker> gebruikers;
        public int AantalGebruikers();
        public IGebruiker GetGebruiker(int i);
        public IGebruiker NieuweGebruiker(string email, string wachtwoord);
    }
}