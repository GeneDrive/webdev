namespace Authenticatie
{
    public class GebruikerContext : IGebruikerContext
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

        public Gebruiker NieuweGebruiker(string email, string wachtwoord)
        {
            Gebruiker user = new Gebruiker(email, wachtwoord);
            gebruikers.Add(user);
            return user;
        }
    }
}