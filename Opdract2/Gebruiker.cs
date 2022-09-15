namespace Authenticatie
{
    class Gebruiker
    {
        public string Wachtwoord {get;set;}
        public string Email {get;set;}
        public VerificatieToken verificatieToken {get;}

        public Gebruiker(string email, string wachtwoord)
        {
            this.Email = email;
            this.Wachtwoord = wachtwoord;
            verificatieToken = new VerificatieToken();
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