namespace Authenticatie
{
    class VerificatieToken
    {
        public string token{get;set;} = "sasgsd12345";
        public DateTime verloopDatum{get;set;} = DateTime.Today.AddDays(3);
    }
}