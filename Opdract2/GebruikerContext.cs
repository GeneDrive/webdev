namespace Authenticatie
{
    class GebruikerContext : IGebruikerContext
    {
        private List<Gebruiker> gebruikers = new List<Gebruiker>();

        public int AantalGebruikers()
        {
            return gebruikers.Count;
        }

        public Gebruiker GetGebruiker(int i)
        {
            return gebruikers[i];
        }

        public Gebruiker NieuweGebruiker(string wachtwoord, string email)
        {
            for(int i = 0; i < AantalGebruikers(); i++)
            {
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