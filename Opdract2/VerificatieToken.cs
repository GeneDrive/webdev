namespace Authenticatie
{
    public class VerificatieToken : IVerificatieToken
    {
        public string token{get;set;} = "sasgsd12345";
        public DateTime verloopDatum{get;set;} = DateTime.Today.AddDays(3);
    }
}