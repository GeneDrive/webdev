namespace Authenticatie
{
    public interface IGebruiker
    {
        public string Wachtwoord {get;set;}
        public string Email {get;set;}
        public IVerificatieToken verificatieToken {get;}
        public bool Geverifieerd();
        public void Verifieer();
    }
}