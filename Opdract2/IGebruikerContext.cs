namespace Authenticatie
{
    public interface IGebruikerContext
    {
        private List<Gebruiker> gebruikers;
        public int AantalGebruikers();
        public Gebruiker GetGebruiker(int i);
        public Gebruiker NieuweGebruiker(string wachtwoord, string email);
    }
}