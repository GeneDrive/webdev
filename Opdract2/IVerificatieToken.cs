namespace Authenticatie
{
    public interface IVerificatieToken
    {
        public string token{get;set;}
        public DateTime verloopDatum{get;set;}
    }
}