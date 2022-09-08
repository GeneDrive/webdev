namespace Authenticatie
{
    class GebruikerContext
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

        public void NieuweGebruiker(string wachtwoord, string email)
        {
            gebruikers.Add(new Gebruiker(wachtwoord, email));
        }
    }
}