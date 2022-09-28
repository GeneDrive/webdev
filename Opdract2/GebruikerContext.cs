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
            IGebruiker user = new Gebruiker(email, wachtwoord);
            gebruikers.Add(user);
            return user;
        }
    }
}