using Authenticatie;

namespace Authenticatie
{
    public class GebruikerContextMock : IGebruikerContext
    {
        private List<IGebruiker> gebruikers = new List<IGebruiker>();

        public GebruikerContextMock()
        {
            gebruikers.Add(new Gebruiker("man@hotmail.com", "rgaewrgf"));
            gebruikers.Add(new Gebruiker("reeeee@hotmail.com", "rgaewrgf"));
        }
        public int AantalGebruikers()
        {
            return gebruikers.Count;
        }
        public IGebruiker GetGebruiker(int i)
        {
            return gebruikers[i];
        }

        public bool userWasAdded = false;
        public IGebruiker NieuweGebruiker(string email, string wachtwoord)
        {
            userWasAdded = false;
            bool exists = false;
            for(int i = 0; i < AantalGebruikers(); i++)
            {
                if(GetGebruiker(i).Email == email)
                {
                    System.Console.WriteLine("Deze gebruiker bestaat al!");
                    exists = true;
                }
            }

            if(!exists)
            {
                IGebruiker user = new GebruikerMock(email, wachtwoord);
                gebruikers.Add(user);
                
                userWasAdded = true;
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}