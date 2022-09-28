using Authenticatie;

namespace Authenticatie
{
    public class GebruikerContextMock : IGebruikerContext
    {
        private List<Gebruiker> gebruikers = new List<Gebruiker>();

        public int AantalGebruikers()
        {
            return 1;
        }
        public Gebruiker GetGebruiker(int i)
        {
            return new Gebruiker("man@hotmail.com", "rgaewrgf");
        }

        public Gebruiker NieuweGebruiker(string email, string wachtwoord)
        {
            return new Gebruiker(email, wachtwoord, -3);
        }
    }
}