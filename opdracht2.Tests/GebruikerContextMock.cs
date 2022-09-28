using Authenticatie;

namespace Authenticatie
{
    public class GebruikerContextMock : IGebruikerContext
    {
        private List<IGebruiker> gebruikers = new List<IGebruiker>();

        public int AantalGebruikers()
        {
            return 1;
        }
        public IGebruiker GetGebruiker(int i)
        {
            return new Gebruiker("man@hotmail.com", "rgaewrgf");
        }

        public IGebruiker NieuweGebruiker(string email, string wachtwoord)
        {
            return new GebruikerMock(email, wachtwoord);
        }
    }
}