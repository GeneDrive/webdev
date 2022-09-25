namespace Authenticatie
{
    public class GebruikerContext : IGebruikerContext
    {
        private List<IGebruiker> gebruikers = new List<IGebruiker>();

        public int AantalGebruikers()
        {
            return gebruikers.Count;
        }

        public IGebruiker GetGebruiker(int i)
        {
            return gebruikers[i];
        }

        public IGebruiker NieuweGebruiker(string email, string wachtwoord)
        {
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
                IGebruiker user = new Gebruiker(email, wachtwoord);
                gebruikers.Add(user);
                return user;
            }
            else
            {
                return null;
            }
            
        }
    }
}