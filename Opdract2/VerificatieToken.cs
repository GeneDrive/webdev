namespace Authenticatie
{
    class VerificatieToken
    {
        // wat bedoelen ze met <<auto??
        public string token{get;set;} = "sasgsdfsgsefghsdrg";
        public DateTime verloopDatum{get;set;} = DateTime.Today.AddDays(3);
    }
}