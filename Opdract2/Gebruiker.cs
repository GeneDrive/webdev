namespace Authenticatie
{
    public class Gebruiker : IGebruiker
    {
        public string Wachtwoord {get;set;}
        public string Email {get;set;}
        public IVerificatieToken verificatieToken {get;}

        public Gebruiker(string email, string wachtwoord, int vervalDatum = 3)
        {
            this.Email = email;
            this.Wachtwoord = wachtwoord;
            verificatieToken = new VerificatieToken(vervalDatum);
        }
        public bool Geverifieerd() 
        {
            bool boolToReturn = false;
            
            if(verificatieToken.token == "")
            {
                boolToReturn = true;
            }

            return boolToReturn;
        }

        public void Verifieer() 
        {
            verificatieToken.token = "";
        }
    }
}