namespace Authenticatie
{
    class Gebruiker
    {
        // wat bedoelen ze met <<auto??
        public string Wachtwoord {get;set;}
        public string Email {get;set;}
        private VerificatieToken verificatieToken = new VerificatieToken();

        public bool Geverifieerd() 
        {
            bool boolToReturn = false;
            
            if(verificatieToken.token == "")
            {
                boolToReturn = true;
            }

            return boolToReturn;
        }
    }
}