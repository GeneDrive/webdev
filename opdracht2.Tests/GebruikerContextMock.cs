using Authenticatie;

namespace Authenticatie
{
    public class GebruikerContextMock : IGebruikerContext
    {
        private List<Gebruiker> gebruikers = new List<Gebruiker>(new Gebruiker("man@hotmail.com", "rgaewrgf"), new Gebruiker("reeeee@hotmail.com", "rgaewrgf"), new Gebruiker("hans@hotmail.com", "rgaewrgf"));

        public int AantalGebruikers()
        {
            return gebruikers.Count;
        }
        public Gebruiker GetGebruiker(int i)
        {
            return gebruikers[i];
        }

        public int aantalLoops = 0;
        public Gebruiker NieuweGebruiker(string wachtwoord, string email)
        {
            aantalLoops = 0;
            for(int i = 0; i < AantalGebruikers(); i++)
            {
                aantalLoops++;
                if(GetGebruiker(i).Email == email)
                {
                    System.Console.WriteLine("Deze gebruiker bestaat al!");
                    return null;
                }
            }
            Gebruiker user = new Gebruiker(email, wachtwoord);
            gebruikers.Add(user);

            return user;
        }
    }
}