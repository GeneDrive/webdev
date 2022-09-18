namespace Authenticatie
{
    public class GebruikerMock : IGebruiker
    {
        public string Wachtwoord {get;set;}
        public string Email {get;set;}
        public IVerificatieToken verificatieToken {get;}

        public GebruikerMock(string email, string wachtwoord)
        {
            this.Email = email;
            this.Wachtwoord = wachtwoord;
            verificatieToken = new VerificatieTokenMock();
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